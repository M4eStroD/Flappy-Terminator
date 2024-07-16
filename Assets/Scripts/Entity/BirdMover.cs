using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidBody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private IInputService _inputService;

    private void Start()
    {
        _inputService = ServiceLocator.Instance.Resolve<IInputService>();
        _inputService.JumpButtonClick += OnJumpButtonClick;

        _startPosition = transform.position;
        _rigidBody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnJumpButtonClick()
    {
        _rigidBody2D.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidBody2D.velocity = Vector3.zero;
    }
}
