using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MassScale : MonoBehaviour
{
    [SerializeField]
    private const float scaleFactor = 0.01f;
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
