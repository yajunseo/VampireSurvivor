using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Player _player = null;
    public Player player { get { return _player; } }

    [SerializeField] PoolManager _poolManger = null;
    public PoolManager poolManger { get { return _poolManger; } }

    private float _gameTime;
    public float gameTime { get { return _gameTime; } }

    public static float MAX_GAME_TIME = 2 * 10f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        _gameTime += Time.deltaTime;

        if(_gameTime > MAX_GAME_TIME)
        {
            _gameTime = MAX_GAME_TIME;
        }
    }
}
