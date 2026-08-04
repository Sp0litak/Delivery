using TMPro;
using UnityEngine;
using DG.Tweening;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private Money _money;
    private Tween _tween;

    public void Initialize(Money money)
    {
        _money = money;

        _money.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(_money.Amount);
    }

    private void OnMoneyChanged(int amount)
    {
        _moneyText.text = amount.ToString();
        _tween?.Kill();
        _moneyText.transform.localScale = Vector3.one;
        _tween = _moneyText.transform
            .DOPunchScale(Vector3.one * 0.2f, 0.25f);
    }

    private void OnDestroy()
    {
        if (_money != null)
            _money.MoneyChanged -= OnMoneyChanged;
    }
}