using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Canvas _died;
    [SerializeField] private Canvas _mainMenu;

    private void DisableCanvases()
    {
        _playButton.gameObject.SetActive(false);
        _died.enabled = false;
        _mainMenu.enabled = false;
    }

    public void GameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                DisableCanvases();
                _playButton.gameObject.SetActive(true);
                break;
            case GameState.Died:
                DisableCanvases();
                _died.enabled = true;
                break;
            case GameState.MainMenu:
                DisableCanvases();
                _mainMenu.enabled = true;
                break;
        }
    }
}
