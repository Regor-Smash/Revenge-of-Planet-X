using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraEffects : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float zoomFactor = 2;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ZoomIn();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        if (cam.orthographic)
        {
            cam.orthographicSize /= zoomFactor;
        }
        else
        {
            cam.fieldOfView /= zoomFactor;
        }
    }

    private void ZoomOut()
    {
        if (cam.orthographic)
        {
            cam.orthographicSize *= zoomFactor;
        }
        else
        {
            cam.fieldOfView *= zoomFactor;
        }
    }
}
