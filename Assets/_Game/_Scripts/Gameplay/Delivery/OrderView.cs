using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _addressText;
    [SerializeField] private TextMeshProUGUI _rewardText;
    [SerializeField] private Button _pickOrderButton;

    private PackageConfig _packageConfig;

    public void Initialize(PackageConfig packageConfig)
    {
        _packageConfig = packageConfig;

        _addressText.text = packageConfig.address;
        _rewardText.text = packageConfig.reward.ToString();

        _pickOrderButton.onClick.RemoveAllListeners();
        _pickOrderButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log($"Picked order: {_packageConfig.address}");
    }
}
