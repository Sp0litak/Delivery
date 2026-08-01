using UnityEngine;

public static class PackageFactory
{
    public static Package Create(Vector3 position, PackageConfig packageConfig)
    {
        if (packageConfig.type == PackageType.Default)
        {
            Package _packagePrefab = Resources.Load<Package>("Package");
            _packagePrefab = GameObject.Instantiate(_packagePrefab, position, Quaternion.identity);

            _packagePrefab.Initialize(packageConfig);
            return _packagePrefab;
        }
        return null;
    }
}