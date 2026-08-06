using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Money _money;
    private SaveService _saveService;
    private OrderService _orderService;
    void Awake()
    {
        //Init
        _money = new Money(0);
        _saveService = new SaveService();

        ServiceLocator.Register(_money);
        ServiceLocator.Register(_saveService);
        ServiceLocator.Register(new InputService(new PlayerInputSystem()));

        _orderService = new OrderService();

        ServiceLocator.Register(_orderService);

        SaveData data = _saveService.Load();

        if (data != null)
        {
            _money.SetAmount(data.Money);

            var orders = _orderService.GetOrders();

            for (int i = 0; i < orders.Count && i < data.CompletedOrders.Count; i++)
            {
                orders[i].SetDelivered(data.CompletedOrders[i]);
            }
        }

        _player.Initialize();
    }
}
