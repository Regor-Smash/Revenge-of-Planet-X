using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string movementInput = "Vertical";

    [SerializeField]
    private float speed = 0.75f;

    private float startMass;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startMass = rb.mass;
    }

    void Update()
    {
        Move(Input.GetAxis(movementInput));
    }

    private void Move(float axis)
    {
        //F = m a. I supply F.
        float massFactor = startMass * startMass / rb.mass;
        // a = speed * (startMass/ mass)^2
        rb.AddForce(new Vector2(0, axis * speed * massFactor), ForceMode2D.Force);
    }
}
