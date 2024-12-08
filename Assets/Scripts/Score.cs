using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int Count{get; private set;}

    public event Action<int> ScoreChanged;
    
    public void Increment() {
        Count++;
        ScoreChanged?.Invoke(Count);
    }

    public void ResetScore() {
        Count = 0;
        ScoreChanged?.Invoke(Count);
    }
}
