using System.IO;
using UnityEngine;

public class SaveService
{
    private readonly string _path;

    public SaveService()
    {
        _path = Path.Combine(Application.persistentDataPath, "save.json");
    }

    public void Save(Money money, OrderService orderService)
    {
        SaveData data = new SaveData
        {
            Money = money.Amount
        };

        foreach (Order order in orderService.GetOrders())
        {
            data.CompletedOrders.Add(order.IsDelivered);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(_path, json);
    }

    public SaveData Load()
    {
        if (!File.Exists(_path))
            return null;

        string json = File.ReadAllText(_path);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public bool HasSave()
    {
        return File.Exists(_path);
    }

    public void Delete()
    {
        if (File.Exists(_path))
            File.Delete(_path);
    }
}