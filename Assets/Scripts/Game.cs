using UnityEngine;

public class Game : MonoBehaviour
{
    private void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("A collider has entered the DoorObject trigger");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("A collider is inside the DoorObject trigger");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("A collider has exited the DoorObject trigger");
    }
}
