using System;

public class Order
{
    public string Id { get; }
    public string Address { get; }
    public bool IsDelivered { get; private set; }

    public event Action Delivered;

    public Order(string address)
    {
        Id = Guid.NewGuid().ToString();
        Address = address;
    }

    public void Deliver()
    {
        IsDelivered = true;
        Delivered.Invoke();
    }
}