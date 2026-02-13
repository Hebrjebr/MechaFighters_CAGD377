using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("PLAY_Test");
    }

    public void ControlsMenu()
    {
        SceneManager.LoadSceneAsync("CONTROLS_Test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
