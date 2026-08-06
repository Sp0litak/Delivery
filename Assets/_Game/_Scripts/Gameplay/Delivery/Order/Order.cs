using System;

public class Order
{
    public string Address { get; }
    public bool IsDelivered { get; private set; }
    public int Reward { get; }
    public int Timer { get; }

    public event Action Delivered;

    public Order(string address, int reward, int timer)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be empty.", nameof(address));

        if (reward < 0)
            throw new ArgumentOutOfRangeException(nameof(reward));

        if (timer < 0)
            throw new ArgumentOutOfRangeException(nameof(timer));

        Address = address;
        Reward = reward;
        Timer = timer;
    }

    public void Deliver()
    {
        IsDelivered = true;
        Delivered?.Invoke();
    }

    public void SetDelivered(bool delivered)
    {
        IsDelivered = delivered;
    }
}