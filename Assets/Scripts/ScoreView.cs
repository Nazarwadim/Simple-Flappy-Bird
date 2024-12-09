using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;

    public Sprite[] digitSprites;

    private void DisplayScore(int score)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        string scoreStr = score.ToString();
        for (int i = 0; i < scoreStr.Length; i++)
        {
            int digit = int.Parse(scoreStr[i].ToString());
            GameObject digitObj = new();
            digitObj.transform.SetParent(transform);
            Image image = digitObj.AddComponent<Image>();
            image.preserveAspect = true;
            image.sprite = digitSprites[digit];
            RectTransform rectTransform = digitObj.GetComponent<RectTransform>();

            rectTransform.localPosition = new Vector3(((float)i - (scoreStr.Length - 1) / 2.0f) * (rectTransform.rect.width / 1.5f), 0, 0);
            rectTransform.localScale /= 1.5f;
        }
    }

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int amount)
    {
        DisplayScore(amount);
    }
}
