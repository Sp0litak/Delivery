using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private ThirdPersonMovement _thirdPersonMovement;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private MoneyView _moneyView;
    private Money _money;
    public void Initialize()
    {
        _money = ServiceLocator.Get<Money>();
        _thirdPersonMovement.Initialize();
        _cameraLook.Initialize();
        _interactor.Initialize();
        _moneyView.Initialize(_money);
    }
}
