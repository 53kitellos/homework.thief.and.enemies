using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private float _currentTime = 0;
    private float _deltaSpawnTime = 2;
    private bool _enemyTurnSpawn = true;


    private void Update()
    {
        if (Time.time >= _currentTime) 
        {
            _currentTime += _deltaSpawnTime;

            if (_enemyTurnSpawn)
            {
                GameObject newEnemy = Instantiate(_enemy, new Vector3(2, 2, 0), Quaternion.identity);
                _enemyTurnSpawn=false;
            }
            else
            {
                GameObject newEnemy2 = Instantiate(_enemy, new Vector3(-2, 2, 0), Quaternion.identity);
                _enemyTurnSpawn=true;
            }
        }
    }
}
