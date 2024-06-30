using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Player _player = null;
    public Player player { get { return _player; } }

    private void Awake()
    {
        instance = this;
    }
}
