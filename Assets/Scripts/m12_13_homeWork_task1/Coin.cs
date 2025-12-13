using UnityEngine;

namespace m12_13_homeWork_task1
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _nominal;
        public float GetNominal() => _nominal;
    }
}