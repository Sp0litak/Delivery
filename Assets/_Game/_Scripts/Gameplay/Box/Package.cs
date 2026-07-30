using UnityEngine;

public class Package : MonoBehaviour, IPickupable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;
    [SerializeField] private PackageConfig _packageConfig;
    private bool _isPickedUp = false;
    private Order _order;
    private OrderService _orderService;
    public Order Order => _order;

    private void Start()
    {
        _order = new Order(_packageConfig.address);
        _orderService = ServiceLocator.Get<OrderService>();
        _orderService.AddOrder(_order.Id);
    }

    public void PickUp(Transform parent)
    {
        if (!_isPickedUp)
        {
            transform.SetParent(parent, false);

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            if (_rb != null)
            {
                _rb.linearVelocity = Vector3.zero;
                _rb.angularVelocity = Vector3.zero;
                _rb.isKinematic = true;
            }
            _isPickedUp = true;
        }
        else
        {
            Drop();
        }
    }

    public void Drop()
    {
        transform.SetParent(null);

        if (_rb != null)
        {
            _rb.isKinematic = false;
        }
        _isPickedUp = false;
    }
}