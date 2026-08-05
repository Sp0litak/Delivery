using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensitivity = 6f;
    [SerializeField] private float _minPitch = -80f;
    [SerializeField] private float _maxPitch = 80f;

    private InputService _input;

    private float _pitch;

    public void Initialize()
    {
        _input = ServiceLocator.Get<InputService>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        Vector2 look = _input.Look * _sensitivity * Time.deltaTime;

        _pitch -= look.y;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        transform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);

        _player.Rotate(Vector3.up * look.x);
    }
}