using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
public class Bird : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Score _score;

    private BirdMovement _birdMovement;
    
    private void OnEnable()
    {
        _birdMovement = GetComponent<BirdMovement>();
    }

    public void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                _score.ResetScore();
                _birdMovement.CanMove = true;
                _birdMovement.transform.position = _startPosition.position;
                _birdMovement.transform.rotation = _startPosition.rotation;
                break;
            case GameState.Died:
                _birdMovement.CanMove = false;
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
