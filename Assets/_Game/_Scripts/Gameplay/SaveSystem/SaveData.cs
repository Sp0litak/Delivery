using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int Money;
    public List<bool> CompletedOrders = new();
}
