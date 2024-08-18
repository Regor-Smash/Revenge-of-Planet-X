using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleParallax : MonoBehaviour
{
    private SpriteRenderer render;
    [SerializeField]
    private bool loop = false;

    [SerializeField]
    private HurdleInSpace referenceSpeed;
    [SerializeField]
    private float parallaxFactor = 1f;
    private float paraVelocity { get { return referenceSpeed.StartSpeed; } }

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(-paraVelocity * Time.deltaTime * Mathf.Clamp01(parallaxFactor), 0, 0);

        //If out of site flip to other side to go again
        if(loop && !render.isVisible && transform.position.x < 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
