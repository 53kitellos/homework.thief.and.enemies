using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    public GameObject Enemy;
    private float _currentTime = 0;
    private float _deltaSpawnTime = 2;
    private bool _enemyTurnSpawn = true;


    private void Update()
    {
        Debug.Log(Time.time);

        if (Time.time >= _currentTime) 
        {
            _currentTime += _deltaSpawnTime;

            if (_enemyTurnSpawn)
            {
                GameObject newEnemy = Instantiate(Enemy, new Vector3(2, 2, 0), Quaternion.identity);
                _enemyTurnSpawn=false;
            }
            else
            {
                GameObject newEnemy2 = Instantiate(Enemy, new Vector3(-2, 2, 0), Quaternion.identity);
                _enemyTurnSpawn=true;
            }
        }
    }
}
