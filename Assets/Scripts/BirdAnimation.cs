using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class BirdAnimation : MonoBehaviour
{
    [SerializeField] private Sprite _spriteUp;
    [SerializeField] private Sprite _spriteMiddle;
    [SerializeField] private Sprite _spriteDown;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetSpriteIfChanged(Sprite sprite)
    {
        if (_spriteRenderer.sprite != sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }


    public void SetMiddleSprite()
    {
        SetSpriteIfChanged(_spriteMiddle);
    }

    public void SetUpSprite()
    {
        SetSpriteIfChanged(_spriteUp);
    }

    public void SetDownSprite()
    {
        SetSpriteIfChanged(_spriteDown);
    }
}

