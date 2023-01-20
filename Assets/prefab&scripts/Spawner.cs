using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() 
    {
        while (true) 
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(2, 2, 0), Quaternion.identity);

            yield return new WaitForSeconds(2);

            GameObject newEnemy2 = Instantiate(_enemy, new Vector3(-2, 2, 0), Quaternion.identity);

            yield return new WaitForSeconds(2);
        }
    }
}
