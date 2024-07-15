using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _offsetX;

    private Vector3 _position;

    private void Update()
    {
        _position = transform.position;
        _position.x = _bird.transform.position.x + _offsetX;
        transform.position = _position;
    }
}
