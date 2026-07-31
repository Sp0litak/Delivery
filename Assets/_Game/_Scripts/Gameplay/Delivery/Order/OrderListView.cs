using UnityEngine;

public class OrderListView : MonoBehaviour
{
    [SerializeField] private PackageDatabase _packageDatabase;
    [SerializeField] private OrderView _orderViewPrefab;
    [SerializeField] private Transform _content;

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
        }
    }
}