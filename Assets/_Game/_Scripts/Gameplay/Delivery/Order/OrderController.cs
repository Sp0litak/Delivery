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
    private Money _money;

    private void Start()
    {
        CreateOrders();
        _money = ServiceLocator.Get<Money>();
    }

    private void Update()
    {
        _timer?.Tick(Time.deltaTime);

        if (_timer != null)
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

    private void CancelOrder()
    {
        if (_currentPackage != null)
            _currentPackage.DestroyPackage();

        _currentOrderView?.SetSelected(false);

        ClearCurrentOrder();
    }

    private void OnDelivered()
    {
        _currentOrder.Delivered -= OnDelivered;

        _money.Add(_currentPackage.Money);

        _currentPackage.DestroyPackage();

        if (_timer != null)
        {
            _timer.Completed -= OnTimerCompleted;
            _timer.Stop();
            _timer = null;
        }

        _timerView.Clear();

        _currentOrderView?.SetSelected(false);
        _currentOrderView.gameObject.SetActive(false);

        _currentOrder = null;
        _currentPackage = null;
        _currentOrderView = null;
    }

    private void OnTimerCompleted()
    {
        Debug.Log("Delivery time has expired");

        FailOrder();
    }

    private void FailOrder()
    {
        _money.ApplyPenalty(_currentPackage.Money);
        if (_currentPackage != null)
            _currentPackage.DestroyPackage();

        _currentOrderView?.SetSelected(false);

        ClearCurrentOrder();
    }

    private void ClearCurrentOrder()
    {
        if (_currentOrder != null)
            _currentOrder.Delivered -= OnDelivered;

        if (_timer != null)
        {
            _timer.Completed -= OnTimerCompleted;
            _timer.Stop();
            _timer = null;
        }

        _timerView.Clear();

        _currentOrder = null;
        _currentPackage = null;
        _currentOrderView = null;
    }
}