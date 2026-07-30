using System;
using System.Collections.Generic;

public class OrderService
{
    Dictionary<string, bool> _orders = new Dictionary<string, bool>();

    public void AddOrder(string id)
    {
        _orders.Add(id, false);
    }

    public void Delivered(string Id)
    {
        _orders[Id] = true;
    }

    public bool IsDelivered(string Id)
    {
        if (_orders.TryGetValue(Id, out bool isProcessed))
        {
            if (isProcessed)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}