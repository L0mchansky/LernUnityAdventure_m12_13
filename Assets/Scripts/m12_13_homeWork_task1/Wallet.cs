using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] Game _game;
    public float Amount { get; private set; }

    public void AddMoney(float value)
    {
        Amount += value;
        _game.CheckWin(Amount);
    }

    public void ResetMoney()
    {
        Amount = 0;
    }
}