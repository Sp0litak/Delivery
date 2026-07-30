using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    void Awake()
    {
        //Init
        ServiceLocator.Register(new InputService(new PlayerInputSystem()));
        ServiceLocator.Register(new OrderService());
        _player.Initialize();
    }
}
