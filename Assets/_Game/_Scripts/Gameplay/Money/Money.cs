using System;

public class Money
{
    private int _amount;

    public int Amount => _amount;

    public event Action<int> MoneyChanged;

    public Money(int initialAmount)
    {
        _amount = Math.Max(0, initialAmount);
    }

    public void Add(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than 0.");

        _amount += amount;
        MoneyChanged?.Invoke(_amount);
    }

    public bool Spend(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than 0.");

        if (_amount < amount)
            return false;

        _amount -= amount;
        MoneyChanged?.Invoke(_amount);

        return true;
    }

    public bool CanSpend(int amount)
    {
        if (amount <= 0)
            return false;

        return _amount >= amount;
    }

    public void ApplyPenalty(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _amount = Math.Max(0, _amount - amount);
        MoneyChanged?.Invoke(_amount);
    }
}