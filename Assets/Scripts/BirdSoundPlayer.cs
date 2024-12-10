using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSetPlayer), typeof(BirdCollisionHandler), typeof(BirdMovement))]
public class BirdSoundPlayer : MonoBehaviour
{
    [SerializeField] private Score _score;

    private BirdCollisionHandler _birdCollisionHandler;
    private AudioSetPlayer _audioSetPlayer;
    private BirdMovement _birdMovement;

    private void Awake()
    {
        _birdMovement = GetComponent<BirdMovement>();
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
        _audioSetPlayer = GetComponent<AudioSetPlayer>();
    }

    private void OnEnable()
    {
        _birdMovement.Jumping += OnJumped;
        _birdCollisionHandler.CollidedWithObstacle += OnDied;
        _score.ScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollidedWithObstacle -= OnDied;
        _score.ScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged(int score)
    {
        if(score != 0) 
        {
            _audioSetPlayer.PlayRandomSoundFromSet("Point");
        }
    }

    private void OnJumped() {
        _audioSetPlayer.PlayRandomSoundFromSet("Wing");
    }

    private void OnDied()
    {
        StartCoroutine(OnDiedPlaySound());
    }

    private IEnumerator OnDiedPlaySound()
    {
        _audioSetPlayer.PlayRandomSoundFromSet("Hit");
        AudioSource audioSource = _audioSetPlayer.GetAudioSource("Hit");
        float remainingTime = audioSource.clip.length / 2;
        yield return new WaitForSeconds(remainingTime);
        _audioSetPlayer.PlayRandomSoundFromSet("Died");
    }

    public void OnGameStateChanged(GameState state) {
        if(state == GameState.Play) {
            _audioSetPlayer.PlayRandomSoundFromSet("Swoosh");
        }
    }
}
