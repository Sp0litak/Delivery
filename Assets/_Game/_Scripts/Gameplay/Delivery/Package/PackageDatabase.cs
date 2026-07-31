using System.Collections.Generic;
using UnityEngine;

public class PackageDatabase : MonoBehaviour
{
    [SerializeField] private List<PackageConfig> _packageConfigs = new List<PackageConfig>();

    public List<PackageConfig> PackageConfigs => _packageConfigs;
}