using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MassCollision : MonoBehaviour
{
    protected Rigidbody2D rb;

    [SerializeField]
    protected float maxMass = 500f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //The object that this script is on is colission.otherRigidbody
        if (collision.rigidbody != null)
        {
            ChangeMass(collision.rigidbody.mass);
        }
    }

    protected virtual void ChangeMass(float otherMass)
    {
        rb.mass *= 0.9f;
    }
}
