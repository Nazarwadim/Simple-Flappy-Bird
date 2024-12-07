using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action Collided;

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        Collided?.Invoke();
    }
}
