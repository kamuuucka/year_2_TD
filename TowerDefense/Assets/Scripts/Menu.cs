using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class responsible for buttons in the game over scene
/// </summary>
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
