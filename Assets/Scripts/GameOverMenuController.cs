using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    public GameManager gameManager;
    public Button mainMenuButton;
    public Button quitButton;

    private void Start()
    {
        // Adding listeners to the buttons
        mainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    private void OnMainMenuButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        SoundManager.Instance.PlayEffect(SoundType.ButtonClick);
        SoundManager.Instance.PlayMusic(SoundType.BackgroundMusic);
    }

    public void OnQuitButtonPressed()
    {
        gameManager.QuitGame();
    }
}
