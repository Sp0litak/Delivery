using UnityEngine;

public class CarryItem : MonoBehaviour
{
    [SerializeField] private Transform rightGrip;
    [SerializeField] private Transform leftGrip;

    public Transform RightGrip => rightGrip;
    public Transform LeftGrip => leftGrip;
}
