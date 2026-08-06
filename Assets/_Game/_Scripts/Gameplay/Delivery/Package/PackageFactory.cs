using UnityEngine;

public static class PackageFactory
{
    public static Package Create(Vector3 position, Order order)
    {
        Package _packagePrefab = Resources.Load<Package>("Package");
        _packagePrefab = GameObject.Instantiate(_packagePrefab, position, Quaternion.identity);
        
        _packagePrefab.Initialize(order);
        return _packagePrefab;
    }
}