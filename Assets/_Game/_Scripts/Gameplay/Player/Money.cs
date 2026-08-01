using System;

public class Money
{
    private int _amount;

    public int Amount => _amount;

    public event Action<int> MoneyChanged;

    public Money(int initialAmount)
    {
        if(initialAmount < 0)
            _amount = 0;
        else
            _amount = initialAmount;
    }

    public void Add(int amount)
    {
        _amount += amount;
        MoneyChanged?.Invoke(_amount);
    }

    public void Spend(int amount)
    {
        _amount -= amount;
        MoneyChanged?.Invoke(_amount);
    }
}
