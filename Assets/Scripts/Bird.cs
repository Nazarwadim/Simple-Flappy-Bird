using UnityEngine;

[RequireComponent(typeof(BirdMovement), typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Score _score;

    private BirdMovement _birdMovement;
    private BirdCollisionHandler _birdCollisionHandler;

    private void OnEnable()
    {
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
        _birdMovement = GetComponent<BirdMovement>();
    }

    public void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                _score.ResetScore();
                _birdCollisionHandler.CanCollide = true;
                _birdMovement.CanMove = true;
                _birdMovement.transform.position = _startPosition.position;
                _birdMovement.transform.rotation = _startPosition.rotation;
                break;
            case GameState.Died:
                _birdCollisionHandler.CanCollide = false;
                _birdMovement.Die();
                _birdMovement.enabled = false;
                
                break;
            case GameState.MainMenu:
                _birdMovement.CanMove = false;
                _birdMovement.transform.position = _startPosition.position;
                _birdMovement.transform.rotation = _startPosition.rotation;
                break;
            case GameState.Pause:
                _birdMovement.CanMove = false;
                break;
        }
    }
}
