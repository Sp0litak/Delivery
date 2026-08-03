using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactorSource;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private float _interactRange = 3f;
    [SerializeField] private Transform _equipItem;

    private InputService _inputService;

    public void Initialize()
    {
        _inputService = ServiceLocator.Get<InputService>();
    }

    private void Update()
    {
        if(_inputService.Interact)
            Interact();
    }

    private void Interact()
    {
        Ray ray = new Ray(_interactorSource.position, _interactorSource.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _interactRange, _interactableLayer))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
                return;
            }
            if (hit.collider.TryGetComponent(out IPickupable pickupable))
            {
                pickupable.PickUp(_equipItem);
                return;
            }
        }
    }
}