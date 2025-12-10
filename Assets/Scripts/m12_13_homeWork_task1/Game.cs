using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _timeToLose;
    [SerializeField] private float _requiredScoreToWin;
    [SerializeField] private GameTimer _gameTimer;

    [SerializeField] private List<GameObject> _coins;

    private bool _gameIsProgress = false;

    private string _msgToWin = "Победа!";
    private string _msgToLose = "Поражение!";

    private void Start()
    {
        _gameIsProgress = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            RestartGame();
        }

        if (_gameIsProgress)
        {
            _gameTimer.UpdateTimer(_timeToLose);

            if (_gameTimer.IsTimerActive == false)
            {
                StopGame(false);
            }
        }
    }

    private void RestartGame()
    {
        foreach (GameObject coin in _coins)
        {
            coin.gameObject.SetActive(true);
        }

        if (_player.TryGetComponent<Wallet>(out Wallet playerWallet))
        {
            playerWallet.ResetMoney();
        }

        _player.SetActive(true);
        _player.transform.position = Vector3.zero;
        _player.transform.rotation = Quaternion.Euler(Vector3.zero);
        _gameIsProgress = true;
        _gameTimer.Reset();
    }

    private void StopGame(bool endGameMode)
    {
        _gameIsProgress = false;
        _player.SetActive(false);

        Debug.Log(endGameMode ? _msgToWin : _msgToLose);
    }

    public void CheckWin(float value)
    {
        if (value >= _requiredScoreToWin)
        {
            StopGame(true);
        }
    }
}
