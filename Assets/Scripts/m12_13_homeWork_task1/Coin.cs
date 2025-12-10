using UnityEngine;

namespace m12_13_homeWork_task1
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinNominal = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Wallet>(out var wallet))
            {
                wallet.AddMoney(_coinNominal);
                gameObject.SetActive(false);
            }
        }
    }
}