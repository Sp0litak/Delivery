using UnityEngine;

public interface IPickupable
{
    public void PickUp(Transform parent);
    public void Drop();
}