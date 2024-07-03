using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoint;
    [SerializeField] float _spawnDuration = 0.2f;
    [SerializeField] SpawnData[] _spawnData;

    int _level;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        _level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), _spawnData.Length - 1);

        if (_timer > _spawnData[_level].spawnTime)
        {
            _timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        Enemy enemy = GameManager.instance.poolManger.Get(0).GetComponent<Enemy>();
        enemy.transform.position = _spawnPoint[UnityEngine.Random.Range(0, _spawnPoint.Length)].position;
        enemy.Init(_spawnData[_level]);
    
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
