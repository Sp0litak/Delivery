using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private Money _money;

    public void Initialize(Money money)
    {
        _money = money;

        _money.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(_money.Amount);
    }

    private void OnMoneyChanged(int amount)
    {
        _moneyText.text = amount.ToString();
    }

    private void OnDestroy()
    {
        if (_money != null)
            _money.MoneyChanged -= OnMoneyChanged;
    }
}