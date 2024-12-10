using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action CollidedWithObstacle;

    public bool CanCollide { get; set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CanCollide)
        {
            CollidedWithObstacle?.Invoke();
        }

    }
}
