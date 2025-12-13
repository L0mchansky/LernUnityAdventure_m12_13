using UnityEngine;

namespace m12_13_homeWork_task2
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Transform _sphereTransform;

        private void Start()
        {
            _sphereTransform.position = _startPosition;
            _sphereTransform.GetComponent<Rigidbody>().WakeUp();
        }

    }
}
