using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private Slider progressBar;
    private float progressValue { get { return Time.timeSinceLevelLoad / duration; } }

    [SerializeField]
    private UnityEvent LevelComplete;

    private void Update()
    {
        progressBar.value = progressValue;

        if (Time.timeSinceLevelLoad > duration)
        {
            LevelComplete?.Invoke();
            Debug.Log("You Won");
        }
    }
}
