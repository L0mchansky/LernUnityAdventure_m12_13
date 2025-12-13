using UnityEngine;

public class Wallet : MonoBehaviour
{
    public float Amount { get; private set; }

    public void AddMoney(float value)
    {
        Amount += value;
    }

    public void ResetMoney()
    {
        Amount = 0;
    }
}