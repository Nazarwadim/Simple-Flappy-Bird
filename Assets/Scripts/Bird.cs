using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMovement), typeof(Score))]
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
            case GameState.Resume:
                _birdMovement.CanMove = true;
                break;
            case GameState.Play:
                _score.ResetScore();
                _birdMovement.CanMove = true;
                _birdMovement.transform.position = _startPosition.position;
                break;
            case GameState.Died:
                _birdMovement.CanMove = false;
                break;
            case GameState.MainMenu:
                _birdMovement.CanMove = false;
                _birdMovement.transform.position = _startPosition.position;
                break;
            case GameState.Pause:
                _birdMovement.CanMove = false;
                break;
        }
    }
}
