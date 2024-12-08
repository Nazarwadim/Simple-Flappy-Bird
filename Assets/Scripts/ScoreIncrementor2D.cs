using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ScoreIncrementor2D : MonoBehaviour
{
    private void OnValidate() {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Score>(out Score score)) {
            score.Increment();
        }
    }
}
