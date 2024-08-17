using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHealth : MassCollision
{
    //Health is tracked as the mass of the player

    #region Variables
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
    #endregion

    private float damageInterval = 1f;
    private float lastDamaged = 0f;
    private float nextDamage { get { return lastDamaged + damageInterval; } }

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
            }
        }
        else if(massRatio < minorDamageThreshold)
        {
            rb.mass *= minorDamageMultiplier;
        }
        else if(massRatio < majorDamageThreshold)
        {
            rb.mass *= majorDamageMultiplier;
        }
        else //other is basically your size or bigger
        {
            Debug.Log("DEATH");
            gameObject.SetActive(false);
        }
        lastDamaged = Time.time;
    }
}
