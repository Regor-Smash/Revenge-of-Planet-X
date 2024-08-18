using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RecordScore : MonoBehaviour
{
    public const string highScorePref = "HighScore";

    int score = 0;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        score = Mathf.RoundToInt(PlayerHealth.Score);
        ShowScore();

        //Highscore calc
        if (PlayerPrefs.HasKey(highScorePref))
        {
            int hScore = Mathf.Max(score, PlayerPrefs.GetInt(highScorePref));
            PlayerPrefs.SetInt(highScorePref, hScore);
        }
        else
        {
            PlayerPrefs.SetInt(highScorePref, score);
        }
        PlayerPrefs.Save();
    }

    private void ShowScore()
    {
        text.text = score.ToString();
    }
}
