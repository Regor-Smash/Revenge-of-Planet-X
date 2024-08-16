using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string movementInput = "Vertical";

    [SerializeField]
    private float speed = 0.5f;

    void Update()
    {
        Move(Input.GetAxis(movementInput));
    }

    private void Move(float axis)
    {
        gameObject.transform.Translate(0, axis * speed, 0);
    }
}
