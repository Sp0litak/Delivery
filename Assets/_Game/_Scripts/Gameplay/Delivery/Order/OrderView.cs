using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _addressText;
    [SerializeField] private TextMeshProUGUI _rewardText;
    [SerializeField] private Button _pickOrderButton;
    [SerializeField] private Button _cancelOrderButton;

    public event Action<OrderView, Order> OrderSelected;
    public event Action OrderCanceled;

    private Order _order;

    public void Initialize(Order order)
    {
        _order = order;

        _addressText.text = _order.Address;
        _rewardText.text = _order.Reward.ToString();

        _pickOrderButton.onClick.RemoveAllListeners();
        _pickOrderButton.onClick.AddListener(OnClick);

        _cancelOrderButton.onClick.RemoveAllListeners();
        _cancelOrderButton.onClick.AddListener(OnCancelClick);

        DisableCancelButton();
        EnablePickButton();
    }

    private void OnClick()
    {
        OrderSelected?.Invoke(this, _order);
    }

    private void OnCancelClick()
    {
        OrderCanceled?.Invoke();
    }

    public void EnablePickButton()
    {
        _pickOrderButton.interactable = true;
    }

    public void DisablePickButton()
    {
        _pickOrderButton.interactable = false;
    }

    public void EnableCancelButton()
    {
        _cancelOrderButton.gameObject.SetActive(true);
    }

    public void DisableCancelButton()
    {
        _cancelOrderButton.gameObject.SetActive(false);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            DisablePickButton();
            EnableCancelButton();
        }
        else
        {
            EnablePickButton();
            DisableCancelButton();
        }
    }
}