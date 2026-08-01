using UnityEngine;

[CreateAssetMenu(fileName = "PackageConfig", menuName = "Scriptable Objects/PackageConfig")]
public class PackageConfig : ScriptableObject
{
    public string address;
    public int reward;
    public PackageType type;
    public int timer;
}
