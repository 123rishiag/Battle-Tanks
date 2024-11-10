using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    public Button replayButton;
    public Button quitButton;

    private void Start()
    {
        // Adding listeners to the buttons
        replayButton.onClick.AddListener(OnReplayButtonPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    private void OnReplayButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void OnQuitButtonPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
