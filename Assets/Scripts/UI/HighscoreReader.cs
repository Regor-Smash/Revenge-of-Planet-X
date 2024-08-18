using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HighscoreReader : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey(RecordScore.highScorePref))
        {
            text.text = PlayerPrefs.GetInt(RecordScore.highScorePref).ToString();
        }
    }
}
