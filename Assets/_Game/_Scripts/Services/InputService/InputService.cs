using UnityEngine;

public class InputService
{
    private readonly PlayerInputSystem _input;
    private bool _isUI = false;

    public InputService(PlayerInputSystem input)
    {
        _input = input;
        EnableGameplay();
    }

    public Vector2 Walk => _input.Player.Move.ReadValue<Vector2>();

    public Vector2 Look => _input.Player.Look.ReadValue<Vector2>();

    public bool Jump => _input.Player.Jump.WasPressedThisFrame();
    public bool Interact =>
    _isUI
        ? _input.UI.Interact.WasPressedThisFrame()
        : _input.Player.Interact.WasPressedThisFrame();

    public void EnableGameplay()
    {
        _isUI = false;
        _input.UI.Disable();
        _input.Player.Enable();
    }

    public void EnableUI()
    {
        _isUI = true;
        _input.Player.Disable();
        _input.UI.Enable();
    }
}