public class OrderService
{
    private Money _money;

    public OrderService()
    {
        _money = ServiceLocator.Get<Money>();
    }

    public void Deliver(Order order)
    {
        order.Deliver();
        _money.Add(order.Reward);
    }

    public void Fail(Order order)
    {
        _money.ApplyPenalty(order.Reward);
    }
}
