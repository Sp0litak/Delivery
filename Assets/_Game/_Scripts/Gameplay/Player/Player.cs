using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private CharacterAnimatorController _characterAnimatorController;
    [SerializeField] private ThirdPersonMovement _thirdPersonMovement;

    public void Initialize()
    {
        _thirdPersonMovement.Initialize();
        _cameraLook.Initialize();
        _characterAnimatorController.Initialize();
    }
}