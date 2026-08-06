using DG.Tweening;
using UnityEngine;

public class DoorsTrigger : MonoBehaviour
{
    [SerializeField] private Transform _rightDoor;
    [SerializeField] private Transform _leftDoor;

    [SerializeField] private float _distance = 1f;
    [SerializeField] private float _duration = 1f;

    private Vector3 _rightClosedPos;
    private Vector3 _leftClosedPos;

    private void Awake()
    {
        _rightClosedPos = _rightDoor.position;
        _leftClosedPos = _leftDoor.position;
    }

    private void OpenDoors()
    {
        _rightDoor.DOKill();
        _leftDoor.DOKill();

        _rightDoor.DOMove(_rightClosedPos + Vector3.back * _distance, _duration);
        _leftDoor.DOMove(_leftClosedPos + Vector3.forward * _distance, _duration);
    }

    private void CloseDoors()
    {
        _rightDoor.DOKill();
        _leftDoor.DOKill();

        _rightDoor.DOMove(_rightClosedPos, _duration);
        _leftDoor.DOMove(_leftClosedPos, _duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OpenDoors();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            CloseDoors();
    }
}