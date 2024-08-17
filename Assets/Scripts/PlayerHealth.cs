using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHealth : MassCollision
{
    //Health is tracked as the mass of the player
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
        if(massRatio < 0.25f)
        {
            rb.mass *= 1.1f;
        }
        else if(massRatio < 0.5f)
        {
            rb.mass *= 0.95f;
        }
        else if(massRatio < 0.8f)
        {
            rb.mass *= 0.8f;
        }
        else //other is basically your size or bigger
        {
            Debug.Log("DEATH");
            gameObject.SetActive(false);
        }
        lastDamaged = Time.time;
    }
}
