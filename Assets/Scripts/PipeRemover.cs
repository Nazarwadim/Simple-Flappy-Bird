using UnityEngine;

public class PipeRemover : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Pipe>(out Pipe pipe)) {
            Destroy(pipe.gameObject, Time.fixedDeltaTime);
        }
    }
}
