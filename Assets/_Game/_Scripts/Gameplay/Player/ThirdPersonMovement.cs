using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 2f;

    private CharacterController _controller;

    private InputService _input;

    private float _verticalVelocity;

    public void Initialize()
    {
        _controller = GetComponent<CharacterController>();

        _input = ServiceLocator.Get<InputService>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = _input.Walk;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * moveInput.y + right * moveInput.x;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);

        if (_controller.isGrounded)
        {
            _verticalVelocity = -2f;

            if (_input.Jump)
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _verticalVelocity += _gravity * Time.deltaTime;

        _controller.Move(Vector3.up * _verticalVelocity * Time.deltaTime);
    }
}