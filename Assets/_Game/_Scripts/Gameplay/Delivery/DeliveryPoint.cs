using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] private string _address;
    private OrderService _orderService;
    private Package _package;

    private void Start()
    {
        _orderService = ServiceLocator.Get<OrderService>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Package"))
        {
            _package = other.GetComponent<Package>();
            Order order = _package.Order;

            if (_address == order.Address && !_orderService.IsDelivered(order.Id))
            {
                _orderService.Delivered(order.Id);
            }
        }
    }
}