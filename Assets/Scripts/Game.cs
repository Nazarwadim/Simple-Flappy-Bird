using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private BirdCollisionHandler _birdCollisionHandler;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private Paralaxes _paralaxes;

    public UnityEvent<GameState> GameStateChanged;

    private GameState _state = GameState.Pause;

    private void ChangeState(GameState state)
    {
        _state = state;
        GameStateChanged?.Invoke(state);
    }

    private void Start()
    {
        _pipeGenerator.IsWorking = false;
        OnMainMenu();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollidedWithObstacle += OnBirdCollided;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollidedWithObstacle -= OnBirdCollided;
    }

    private void OnBirdCollided()
    {
        ChangeState(GameState.Died);

        _pipeGenerator.IsWorking = false;
    }

    public void OnMainMenu()
    {
        _paralaxes.ResetToStartPosition();
        ChangeState(GameState.MainMenu);
    }

    private void OnPause()
    {
        ChangeState(GameState.MainMenu);
    }

    public void OnStart()
    {
        ChangeState(GameState.Play);
        _pipeGenerator.Clear();
        _pipeGenerator.IsWorking = true;

    }

}
