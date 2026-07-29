using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float height = 50f;

    private void LateUpdate()
    {
        transform.position = new Vector3(
            target.position.x,
            height,
            target.position.z);
    }
}