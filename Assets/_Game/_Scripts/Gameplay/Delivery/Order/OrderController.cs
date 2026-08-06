using UnityEngine;

public class OrderController : MonoBehaviour
{
    [SerializeField] private PackageDatabase _packageDatabase;
    [SerializeField] private OrderView _orderViewPrefab;
    [SerializeField] private Transform _content;
    [SerializeField] private Transform _packageSpawnPoint;
    [SerializeField] private TimerView _timerView;

    private Package _currentPackage;
    private Order _currentOrder;
    private OrderView _currentOrderView;
    private Timer _timer;

    private OrderService _orderService;

    private void Start()
    {
        _orderService = ServiceLocator.Get<OrderService>();

        CreateOrders();
    }

    private void Update()
    {
        if (_timer == null)
            return;

        _timer.Tick(Time.deltaTime);

        if (_timer == null)
            return;

        _timerView.SetTime(_timer.RemainingTime);
    }

    private void CreateOrders()
    {
        foreach (PackageConfig config in _packageDatabase.PackageConfigs)
        {
            OrderView view = Instantiate(_orderViewPrefab, _content);
            view.Initialize(config);

            view.OrderSelected += SpawnOrder;
            view.OrderCanceled += CancelOrder;
        }
    }

    private void SpawnOrder(OrderView view, PackageConfig config)
    {
        if (_currentPackage != null)
            return;

        _currentOrderView = view;
        _currentOrderView.SetSelected(true);

        _currentPackage = PackageFactory.Create(_packageSpawnPoint.position, config);
        _currentOrder = _currentPackage.Order;

        _currentOrder.Delivered += OnDelivered;

        _timer = new Timer(config.timer);
        _timer.Completed += OnTimerCompleted;
        _timer.Start();

        _timerView.SetTime(_timer.RemainingTime);
    }

    private void OnDelivered()
    {
        _orderService.Deliver(_currentOrder);

        _currentOrderView.gameObject.SetActive(false);

        RemoveCurrentOrder();
    }

    private void CancelOrder()
    {
        RemoveCurrentOrder();
    }

    private void OnTimerCompleted()
    {
        _orderService.Fail(_currentOrder);

        RemoveCurrentOrder();
    }

    private void RemoveCurrentOrder()
    {
        if (_currentOrder != null)
            _currentOrder.Delivered -= OnDelivered;

        if (_timer != null)
        {
            _timer.Completed -= OnTimerCompleted;
            _timer.Stop();
            _timer = null;
        }

        _currentPackage?.DestroyPackage();

        _currentOrderView?.SetSelected(false);

        _timerView.Clear();

        _currentPackage = null;
        _currentOrder = null;
        _currentOrderView = null;
    }
}