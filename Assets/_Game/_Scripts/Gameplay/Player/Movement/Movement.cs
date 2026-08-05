using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
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
        Vector2 input = _input.Walk;

        Vector3 direction =
            transform.forward * input.y +
            transform.right * input.x;

        direction.Normalize();

        if (_controller.isGrounded)
        {
            if (_verticalVelocity < 0)
                _verticalVelocity = -2f;

            if (_input.Jump)
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _verticalVelocity += _gravity * Time.deltaTime;

        Vector3 velocity = direction * _moveSpeed;
        velocity.y = _verticalVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}