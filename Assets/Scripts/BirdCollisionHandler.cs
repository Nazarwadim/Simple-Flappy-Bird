using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action CollidedWithObstacle;

    void OnTriggerEnter2D(Collider2D other)
    {
        CollidedWithObstacle?.Invoke();
    }
}
