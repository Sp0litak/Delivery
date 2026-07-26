using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private InputService _inputService;

    public void Initialize()
    {
        _inputService = ServiceLocator.Get<InputService>();
    }

    private void Update()
    {
        PlayAnimation();      
    }
    
    private void PlayAnimation()
    {
        if (_inputService.Walk.x == 0 && _inputService.Walk.y == 0)
        {
            _animator.Play("Idle");
        }
        if (_inputService.Walk.x != 0 || _inputService.Walk.y != 0)
        {
            _animator.Play("Walk");
        }

    }
}