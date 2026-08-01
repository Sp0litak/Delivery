using System;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    [SerializeField] private PackageDatabase _packageDatabase;
    [SerializeField] private OrderView _orderViewPrefab;
    [SerializeField] private Transform _content;
    [SerializeField] private Transform _packageSpawnPoint;

    private Package _currentPackage = null;
    private Order _currentOrder = null;
    private OrderView _currentOrderView = null;

    private void Start()
    {
        CreateOrders();
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
    }

    private void CancelOrder()
    {
        if (_currentOrder != null)
            _currentOrder.Delivered -= OnDelivered;

        if (_currentPackage != null)
            Destroy(_currentPackage.gameObject);

        _currentOrderView?.SetSelected(false);

        _currentOrder = null;
        _currentPackage = null;
        _currentOrderView = null;
    }
    private void OnDelivered()
    {
        _currentOrder.Delivered -= OnDelivered;

        _currentOrderView?.SetSelected(false);
        _currentOrderView.gameObject.SetActive(false);

        _currentPackage = null;
        _currentOrder = null;
        _currentOrderView = null;
    }
}