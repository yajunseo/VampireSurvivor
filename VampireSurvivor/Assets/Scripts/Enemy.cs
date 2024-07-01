using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 2.5f;
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] SpriteRenderer _spriter;

    Rigidbody2D _target;
    bool _isLive = true;

    Vector2 _dirVec = Vector2.zero;

    private void OnEnable()
    {
        _target = GameManager.instance.player.rigid;
    }

    private void FixedUpdate()
    {
        if (!_isLive)
            return;

        _dirVec = _target.position - _rigid.position;
        Vector2 nextVec = _dirVec.normalized * _speed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
        _rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!_isLive)
            return;

        _spriter.flipX = _dirVec.x < 0 ? true : false;
    }
}
