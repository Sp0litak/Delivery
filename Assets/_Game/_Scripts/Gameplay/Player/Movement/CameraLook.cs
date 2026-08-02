using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensitivity = 150f;
    [SerializeField] private float _minPitch = -60f;
    [SerializeField] private float _maxPitch = 80f;

    private InputService _input;

    private float pitch;

    public void Initialize()
    {
        _input = ServiceLocator.Get<InputService>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        Vector2 look = _input.Look * Time.deltaTime * _sensitivity;

        _player.Rotate(Vector3.up * look.x);

        pitch -= look.y;
        pitch = Mathf.Clamp(pitch, _minPitch, _maxPitch);

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}