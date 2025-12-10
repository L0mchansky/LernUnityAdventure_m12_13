using UnityEngine;

public class FollowerTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        Vector3 offset = transform.rotation * new Vector3(0, 0, _offset.z);

        transform.position = _target.position + offset;
    }
}
