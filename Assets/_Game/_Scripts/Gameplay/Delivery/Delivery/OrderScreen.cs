using UnityEngine;

public class OrderScreen : MonoBehaviour, IInteractable
{
    [SerializeField] private CanvasGroup _screenText;
    [SerializeField] private CanvasGroup _orderCanvas;

    private InputService _inputService;
    private bool _isOpen;

    private void Start()
    {
        _inputService = ServiceLocator.Get<InputService>();

        SetCanvasState(_orderCanvas, false);
        SetCanvasState(_screenText, false);
    }

    public void Interact()
    {
        _isOpen = !_isOpen;

        SetCanvasState(_orderCanvas, _isOpen);

        if (_isOpen)
            _inputService.EnableUI();
        else
            _inputService.EnableGameplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetCanvasState(_screenText, true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetCanvasState(_screenText, false);
        }
    }

    private void SetCanvasState(CanvasGroup canvasGroup, bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}