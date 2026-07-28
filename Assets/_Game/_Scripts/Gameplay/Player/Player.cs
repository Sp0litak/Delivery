using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private ThirdPersonMovement _thirdPersonMovement;
    [SerializeField] private Interactor _interactor;

    public void Initialize()
    {
        _thirdPersonMovement.Initialize();
        _cameraLook.Initialize();
        _interactor.Initialize();
    }
}