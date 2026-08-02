using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private Movement _movement;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private MoneyView _moneyView;
    private Money _money;
    public void Initialize()
    {
        _money = ServiceLocator.Get<Money>();
        _movement.Initialize();
        _cameraLook.Initialize();
        _interactor.Initialize();
        _moneyView.Initialize(_money);
    }
}
