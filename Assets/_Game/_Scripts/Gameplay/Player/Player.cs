using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private Movement _movement;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private MoneyView _moneyView;

    public void Initialize()
    {
        _movement.Initialize();
        _cameraLook.Initialize();
        _interactor.Initialize();
        _moneyView.Initialize();
    }
}
