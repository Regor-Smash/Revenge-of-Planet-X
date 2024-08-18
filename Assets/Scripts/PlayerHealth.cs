using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHealth : MassCollision
{
    //Health is tracked as the mass of the player

    #region HealthVariables
    [SerializeField]
    float healThreshold = 0.25f;
    [SerializeField]
    float healMultiplier = 1.1f;

    [SerializeField]
    float minorDamageThreshold = 0.5f;
    [SerializeField]
    float minorDamageMultiplier = 0.95f;

    [SerializeField]
    float majorDamageThreshold = 0.8f;
    [SerializeField]
    float majorDamageMultiplier = 0.8f;

    [SerializeField]
    float ExtraLifeHealth = 300;
    #endregion

    [SerializeField]
    private Sprite[] healthSprites; //Lowest first
    private SpriteRenderer healthRenderer;

    [SerializeField]
    private float damageInterval = 1f;

    private float lastDamaged = 0f;
    private float nextDamage { get { return lastDamaged + damageInterval; } }

    #region SFX
    [SerializeField]
    private AudioSource healSound;
    [SerializeField]
    private AudioSource hurtSound;
    [SerializeField]
    private AudioSource deadSound;
    #endregion

    private new void Start()
    {
        base.Start();
        healthRenderer = GetComponent<SpriteRenderer>();
        ChangeSprite();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            ChangeMass(1f);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            ChangeMass((rb.mass*majorDamageThreshold)-1);
        }
    }
#endif

    protected override void ChangeMass(float otherMass)
    {
        if (Time.time < nextDamage)
        {
            return;
        }

        float massRatio = otherMass / rb.mass;
        if (massRatio < healThreshold)
        {
            if (rb.mass * healMultiplier < maxMass)
            {
                rb.mass *= healMultiplier;
                healSound.Play();
            }
        }
        else if(massRatio < minorDamageThreshold)
        {
            rb.mass *= minorDamageMultiplier;
            hurtSound.Play();
        }
        else if(massRatio < majorDamageThreshold)
        {
            rb.mass *= majorDamageMultiplier;
            hurtSound.Play();
        }
        else //other is basically your size or bigger
        {
            if (rb.mass > ExtraLifeHealth)
            {
                rb.mass *= 0.5f;
            }
            else
            {
                Die();
                return;
            }
        }
        if(rb.mass < minMass)
        {
            Die();
            return;
        }

        lastDamaged = Time.time;
        ChangeSprite();
    }

    private float HealthPercent()
    {
        float result = (rb.mass - minMass) / (maxMass - minMass);
        //Debug.Log(rb.mass.ToString() + " is " + (result * 100f).ToString() + "% of health.");
        return result;
    }

    private void ChangeSprite()
    {
        float healthPerc = HealthPercent();

        for (int i = 0; i < healthSprites.Length; i++)
        {
            float threshold = (i + 1f) / healthSprites.Length;
            if(healthPerc < threshold)
            {
                healthRenderer.sprite = healthSprites[i];
                return;
            }
        }
    }

    private void Die()
    {
        deadSound.Play();
        Debug.Log("DEATH");
        gameObject.SetActive(false);
    }
}
