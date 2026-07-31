using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] private string _address;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Package"))
            return;

        Package package = other.GetComponent<Package>();
        Order order = package.Order;

        if (order.Address == _address && !order.IsDelivered)
        {
            order.Deliver();

            Debug.Log($"Order {order.Id} delivered!");
        }
        else
        {
            Debug.Log("idi nah");
        }
    }
}