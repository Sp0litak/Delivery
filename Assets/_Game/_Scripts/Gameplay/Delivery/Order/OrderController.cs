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
        }
    }

    private void SpawnOrder(PackageConfig config)
    {
        if( _currentPackage == null)
        {
            _currentPackage = PackageFactory.Create(_packageSpawnPoint.transform.position, config);
            _currentOrder = _currentPackage.Order;
            _currentOrder.Delivered += OnDelivered;
        }
    }

    private void OnDelivered()
    {
        _currentPackage = null;
        _currentOrder = null;
    }
}