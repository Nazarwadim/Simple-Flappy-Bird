using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action CollidedWithObstacle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Reset");
        CollidedWithObstacle?.Invoke();
    }
}
