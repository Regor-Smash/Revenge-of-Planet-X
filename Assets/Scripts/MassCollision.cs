using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MassCollision : MonoBehaviour
{
    protected Rigidbody2D rb;

    [SerializeField]
    protected float maxMass = 500f;
    [SerializeField]
    protected float minMass = 40f;

    [SerializeField]
    private float damageThreshold = 0.8f;
    [SerializeField]
    private float damageMultiplier = 0.5f;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //The object that this script is on is colission.otherRigidbody
        Rigidbody2D colRb = collision.rigidbody;
        if (colRb != null && colRb.mass  < rb.mass)
        {
            MassCollision mc = colRb.GetComponent<MassCollision>();
            if (mc != null)
            {
                float m = colRb.mass;
                mc.ChangeMass(rb.mass);
                ChangeMass(m);
            }
        }
    }

    protected virtual void ChangeMass(float otherMass)
    {
        if (otherMass / rb.mass < damageThreshold)
            rb.mass *= 0.9f;
        else
            rb.mass *= damageMultiplier;

        if(rb.mass < minMass)
        {
            Destroy(gameObject);
        }
    }
}
