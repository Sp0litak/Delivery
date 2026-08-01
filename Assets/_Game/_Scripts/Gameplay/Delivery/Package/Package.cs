using System;
using UnityEngine;

public class Package : MonoBehaviour, IPickupable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;

    private PackageConfig _packageConfig;
    private bool _isPickedUp;
    public int Money => _packageConfig.reward;
    public Order Order { get; private set; }

    public void Initialize(PackageConfig packageConfig)
    {
        _packageConfig = packageConfig;
        Order = new Order(_packageConfig.address);
        Order.Delivered += OnOrderDelivered;
    }

    private void OnOrderDelivered()
    {
        Order.Delivered -= OnOrderDelivered;

        DestroyPackage(5f);
    }

    private void DestroyPackage(float delay)
    {
        Destroy(gameObject, delay);
    }

    public void PickUp(Transform parent)
    {
        if (!_isPickedUp)
        {
            transform.SetParent(parent, false);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            if (_rb != null)
            {
                _rb.linearVelocity = Vector3.zero;
                _rb.angularVelocity = Vector3.zero;
                _rb.isKinematic = true;
            }

            _isPickedUp = true;
        }
        else
        {
            Drop();
        }
    }

    public void Drop()
    {
        transform.SetParent(null);

        if (_rb != null)
            _rb.isKinematic = false;

        _isPickedUp = false;
    }
}