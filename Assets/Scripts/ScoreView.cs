using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;

    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _text = GetComponent<TextMeshProUGUI>(); 
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable() {
        _score.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int amount) {
        _text.text = amount.ToString();
    }
}
