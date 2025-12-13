using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground groundComponent))
        {
            _player.SetOnGround(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground groundComponent))
        {
            _player.SetOnGround(false);
        }
    }
}
