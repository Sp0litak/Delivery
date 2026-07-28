using UnityEngine;

public class Box : MonoBehaviour, IPickupable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider col;
    private bool _isPickedUp = false;
    public void PickUp(Transform parent)
    {
        if (!_isPickedUp)
        {
            transform.SetParent(parent, false);

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            if (rb != null)
            {
                rb.isKinematic = true;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
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

        if (rb != null)
        {
            rb.isKinematic = false;
        }
        _isPickedUp = false;
    }
}