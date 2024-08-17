using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PauseMenu : MonoBehaviour
{
    private const string pauseAxis = "Cancel";
    private static bool isPaused = false;
    public static bool IsPaused { get { return isPaused; } }
    private Canvas pauseCanvas;

    private void Start()
    {
        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown(pauseAxis))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
