using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoint;
    [SerializeField] float _spawnDuration = 0.2f;

    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _spawnDuration)
        {
            _timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int enemyPrefabCnt = GameManager.instance.poolManger.GetEnemyPrefabCnt();
        GameObject enemy = GameManager.instance.poolManger.Get(UnityEngine.Random.Range(0, enemyPrefabCnt));
        enemy.transform.position = _spawnPoint[UnityEngine.Random.Range(0, _spawnPoint.Length)].position;
    }
}
