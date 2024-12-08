using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private BirdCollisionHandler _birdCollisionHandler;
    [SerializeField] private BirdMovement _birdMovement;
    [SerializeField] private Score _score;
    [SerializeField] private PipeGenerator _pipeGenerator;

    public UnityEvent<GameState> GameStateChanged;

    private GameState _state = GameState.Pause;

    private void ChangeState(GameState state) {
        _state = state;
        GameStateChanged?.Invoke(state);
    }

    private void Start() {
        ChangeState(GameState.MainMenu);
        // _birdMovement.CanMove = false;
        // _pipeGenerator.IsWorking = false;
    }

    private void OnEnable() {
        _birdCollisionHandler.CollidedWithObstacle += OnBirdCollided;
    }

    private void OnDisable() {
        _birdCollisionHandler.CollidedWithObstacle -= OnBirdCollided;
    }

    private void OnBirdCollided() {
        ChangeState(GameState.Died);

        _pipeGenerator.IsWorking = false;
        _birdMovement.CanMove = false;        
    }

    private void OnMainMenu() {
        ChangeState(GameState.MainMenu);
    }

    private void OnStart() {
        ChangeState(GameState.Play);
        _score.ResetScore();
        _pipeGenerator.Clear();
        _pipeGenerator.IsWorking = true;
        _birdMovement.CanMove = true;
        _birdMovement.transform.position = _startPosition.position;

        
    }

}
