using DG.Tweening;
using System;
using UnityEngine;

public class Package : MonoBehaviour, IPickupable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;

    private bool _isPickedUp;
    public int Money => Order.Reward;
    public Order Order { get; private set; }

    public void Initialize(Order order)
    {
        Order = order;
       
        PlaySpawnAnimation();
    }

    private void PlaySpawnAnimation()
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOScale(localScale, 0.35f)
                .SetEase(Ease.OutBack)
        );

        sequence.Join(
            transform.DOLocalRotate(
                new Vector3(0f, 360f, 0f),
                0.35f,
                RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic)
        );
    }

    public void DestroyPackage()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOJump(
                transform.position,
                0.25f,
                1,
                0.25f)
            .SetEase(Ease.OutQuad));

        sequence.Join(
            transform.DOScale(Vector3.zero, 0.3f)
            .SetEase(Ease.InBack));

        sequence.Join(
            transform.DORotate(
                new Vector3(0, 360, 0),
                0.3f,
                RotateMode.FastBeyond360));

        sequence.OnComplete(() =>
        {
            Destroy(gameObject);
        });
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