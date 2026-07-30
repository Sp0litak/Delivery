using System;

public class Order
{
    private readonly string _id;
    private readonly string _address;

    public string Id => _id;
    public string Address => _address;

    public Order(string address)
    {
        _id = Guid.NewGuid().ToString();
        _address = address;
    }
}