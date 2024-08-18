using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MassScale : MonoBehaviour
{
    [SerializeField]
    private float defaultMass = 100f;
    private float scaleFactor { get { return 1f/defaultMass; } }
    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.localScale = Vector3.one * scaleFactor * rb.mass;
    }
}
