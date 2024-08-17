using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string movementInput = "Vertical";

    [SerializeField]
    private float speed = 0.75f;
    [SerializeField]
    private float massFactor = 2f;

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
        float massMult = Mathf.Pow(startMass/rb.mass, Mathf.Clamp(massFactor, 0, 100)) * rb.mass; //startMass * startMass / rb.mass;
        // a = speed * (startMass/ mass)^2
        rb.AddForce(new Vector2(0, axis * speed * massMult), ForceMode2D.Force);
    }
}
