using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HurdleInSpace : MonoBehaviour
{
    [SerializeField]
    private float avgMass = 80f;

    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float spinSpeed = 0.7f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.mass = avgMass * Random.Range(0.7f, 1.5f);
        rb.AddForce(Vector3.left * speed * avgMass, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-spinSpeed, spinSpeed) * avgMass, ForceMode2D.Impulse);
    }
}
