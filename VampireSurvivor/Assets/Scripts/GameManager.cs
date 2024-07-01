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

    private void Awake()
    {
        instance = this;
    }
}
