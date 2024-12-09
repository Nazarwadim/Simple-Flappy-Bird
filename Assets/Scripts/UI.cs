using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Canvas _playButton;
    [SerializeField] private Canvas _died;
    [SerializeField] private Canvas _pauseMenu;
    [SerializeField] private Canvas _mainMenu;

    private void DisableCanvases()
    {
        _playButton.enabled = false;
        _died.enabled = false;
        _pauseMenu.enabled = false;
        _mainMenu.enabled = false;
    }

    public void GameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
            case GameState.Resume:
                DisableCanvases();
                _playButton.enabled = true;
                break;
            case GameState.Died:
                DisableCanvases();
                _died.enabled = true;
                break;
            case GameState.MainMenu:
                DisableCanvases();
                _mainMenu.enabled = true;
                break;
            case GameState.Pause:
                DisableCanvases();
                _pauseMenu.enabled = true;
                break;

        }
    }
}
