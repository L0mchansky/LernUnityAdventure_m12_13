using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _time;
    private float _damagePerSecond = 1;
    private float _timeBetweenDamageTicks = 0.1f;

    private float _damagePerTick;

    private void Awake()
    {
        _damagePerTick = _damagePerSecond * _timeBetweenDamageTicks;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            rocket.TakeDamate(_damagePerTick);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time += Time.deltaTime;

            if(_time > _timeBetweenDamageTicks )
            {
                rocket.TakeDamate(_damagePerTick);

                _time = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time = 0;
        }
    }
}
