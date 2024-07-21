using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Object")]
    private bool _isLive = true;
    public bool isLive { get { return _isLive; } }
    [SerializeField] Player _player = null;
    public Player player { get { return _player; } }
    [SerializeField] PoolManager _poolManger = null;
    public PoolManager poolManger { get { return _poolManger; } }

    [SerializeField] LevelUp _uiLevelUp = null;
    public LevelUp uiLevelUp { get { return _uiLevelUp; } }

    [Header("Game Control")]
    private float _gameTime;
    public float gameTime { get { return _gameTime; } }
    public static float MAX_GAME_TIME = 2 * 10f;

    [Header("Player Info")]
    public int level;
    public int kill;
    public int health;
    public int maxHealth = 100;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600};

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;

        uiLevelUp.Select(0);
    }

    private void Update()
    {
        if (!_isLive)
            return;

        _gameTime += Time.deltaTime;

        if(_gameTime > MAX_GAME_TIME)
        {
            _gameTime = MAX_GAME_TIME;
        }
    }

    public void GetExp()
    {
        exp++;

        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        _isLive = false;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        _isLive = true;
        Time.timeScale = 1.0f;
    }
}
