using System.Collections.Generic;

public class OrderService
{
    private Money _money;
    private SaveService _saveService;

    private List<Order> _orders = new List<Order>
    {
        new Order("A-Mart", 100, 60),
        new Order("GAS", 200, 10),

    };

    public OrderService()
    {
        _money = ServiceLocator.Get<Money>();
        _saveService = ServiceLocator.Get<SaveService>();
    }

    public void Deliver(Order order)
    {
        _money.Add(order.Reward);
        _saveService.Save(_money, this);
    }

    public void Fail(Order order)
    {
        _money.ApplyPenalty(order.Reward);
    }

    public List<Order> GetOrders()
    {
        return _orders;
    }
}
