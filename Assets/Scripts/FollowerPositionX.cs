using UnityEngine;

public class FollowerPositionX : MonoBehaviour
{
    [SerializeField] private Transform _transformToFollow;
    [SerializeField] private float _offset;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = _transformToFollow.position.x + _offset;
        transform.position = pos;
    }
}
