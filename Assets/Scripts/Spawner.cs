using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _waitingSpawn;

    private Transform[] _allPoints;

    private void Awake()
    {
        _allPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnEnemy(_waitingSpawn));
    }

    private IEnumerator SpawnEnemy(float waitingSpawn)
    {
        var waiting = new WaitForSeconds(waitingSpawn);

        while (true)
        {
            for (int i = 1; i < _allPoints.Length; i++)
            {
                Instantiate(_enemy, _allPoints[i].position, Quaternion.identity);
                yield return waiting;
            }
        }
    }
}
