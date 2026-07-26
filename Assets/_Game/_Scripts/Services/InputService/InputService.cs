using System;
using UnityEngine;

public class InputService
{
    private readonly PlayerInputSystem _input;

    public InputService(PlayerInputSystem input)
    {
        _input = input;
        _input.Player.Enable();
    }

    public Vector2 Walk => _input.Player.Move.ReadValue<Vector2>();

    public Vector2 Look => _input.Player.Look.ReadValue<Vector2>();

    public bool Jump => _input.Player.Jump.WasPressedThisFrame();
    public bool Interact => _input.Player.Interact.WasPressedThisFrame();
}