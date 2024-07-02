using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] SpriteRenderer _spriter;
    [SerializeField] Animator _animator;
    [SerializeField] RuntimeAnimatorController[] _animControllers;

    Rigidbody2D _target;
    bool _isLive = true;

    float _speed = 0f;
    float _health = 1f;
    float _maxHealth = 1f;

    Vector2 _dirVec = Vector2.zero;

    private void OnEnable()
    {
        _target = GameManager.instance.player.rigid;
        _isLive = true;
        _health = _maxHealth;
    }

    public void Init(SpawnData data)
    {
        _animator.runtimeAnimatorController = _animControllers[data.spriteType - 1];
        _speed = data.speed;
        _maxHealth = data.health;
        _health = data.health;
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
