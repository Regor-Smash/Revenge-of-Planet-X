using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadSceneNum (int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LodSceneName (string name)
    {
        SceneManager.LoadScene(name);
    }
}
