using System;

public class Order
{
    public string Address { get; }
    public bool IsDelivered { get; private set; }
    public int Reward { get; }

    public event Action Delivered;

    public Order(string address, int reward)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be empty.", nameof(address));

        if (reward < 0)
            throw new ArgumentOutOfRangeException(nameof(reward), "Reward cannot be negative.");

        Address = address;
        Reward = reward;
    }

    public void Deliver()
    {
        if (IsDelivered)
            return;

        IsDelivered = true;
        Delivered?.Invoke();
    }
}