using UnityEngine;

public class CoinInteractor : MonoBehaviour
{
    [SerializeField] Wallet wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out m12_13_homeWork_task1.Coin coin) == false)
            return;

        wallet.AddMoney(coin.GetNominal());
        coin.gameObject.SetActive(false);
    }
}