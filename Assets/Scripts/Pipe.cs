using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Collider2D))]
public class Pipe : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _pipeUp;
    [SerializeField] private SpriteRenderer _pipeDown;
    [SerializeField] private float _holeSize;
    [SerializeField] private float _yPosition;


    private float _halfPipeHeigth;
    private void OnEnable()
    {
        _halfPipeHeigth = _pipeUp.bounds.size.y / 2f;
    }

    public void SetHoleSize(float holeSize)
    {
        _holeSize = holeSize;
    }

    public void SetYPosition(float yPosition)
    {
        _yPosition = yPosition;

        Vector3 pipeUp = _pipeUp.transform.position;
        Vector3 pipeDown = _pipeDown.transform.position;
        pipeUp.y = yPosition + _holeSize / 2f + _halfPipeHeigth;
        pipeDown.y = yPosition - _holeSize / 2f - _halfPipeHeigth;

        Collider2D[] colliders = GetComponents<Collider2D>();
        colliders[0].offset = new Vector2(0, pipeUp.y);
        colliders[1].offset = new Vector2(0, pipeDown.y);

        _pipeUp.transform.position = pipeUp;
        _pipeDown.transform.position = pipeDown;
    }
}
