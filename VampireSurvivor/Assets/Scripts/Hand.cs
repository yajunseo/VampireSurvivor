using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Hand : MonoBehaviour
{
    [SerializeField]private bool _isLeft;
    [SerializeField] SpriteRenderer _spriter;
    public SpriteRenderer spriter { get { return _spriter; } }

    SpriteRenderer _playerSpriter;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.35f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0,0,-35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);

    const int FRONT_SORTING_ORDER = 6;
    const int BACK_SORTING_ORDER = 4;

    private void Awake()
    {
        _playerSpriter = GameManager.instance.player.GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        bool isReverse = _playerSpriter.flipX;

        if (_isLeft) 
        {
            transform.localRotation = isReverse ? leftRotReverse : leftRot;
            _spriter.flipY = isReverse;
            _spriter.sortingOrder = isReverse ? BACK_SORTING_ORDER : FRONT_SORTING_ORDER;
        }

        else
        {
            transform.localPosition = isReverse ? rightPosReverse : rightPos;
            _spriter.flipX = isReverse;
            _spriter.sortingOrder = isReverse ? FRONT_SORTING_ORDER : BACK_SORTING_ORDER;
        }
    }
}
