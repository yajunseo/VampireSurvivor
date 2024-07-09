using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] SpriteRenderer _spriter;
    [SerializeField] Animator _animator;
    [SerializeField] Collider2D _collider;
    [SerializeField] RuntimeAnimatorController[] _animControllers;

    Rigidbody2D _target;
    bool _isLive = true;

    WaitForFixedUpdate _wait;

    float _speed = 0f;
    float _health = 1f;
    float _maxHealth = 1f;

    Vector2 _dirVec = Vector2.zero;

    private void Awake()
    {
        _wait = new WaitForFixedUpdate();
    }

    private void OnEnable()
    {
        _target = GameManager.instance.player.rigid;
        _isLive = true;
        _collider.enabled = true;
        _rigid.simulated = true;
        _spriter.sortingOrder = 2;
        _animator.SetBool("Dead", false);
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
        if (!_isLive || _animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !_isLive)
            return;

        Bullet bullet = collision.GetComponent<Bullet>();

        _health -= bullet.damage;
        StartCoroutine(KnockBack());

        if(_health > 0)
        {
            _animator.SetTrigger("Hit");
        }

        else
        {
            Dead();
        }
    }

    IEnumerator KnockBack()
    {
        yield return _wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;

        _rigid.AddForce(dirVec.normalized * 3.0f, ForceMode2D.Impulse);
    }

    private void Dead()
    {
        _isLive = false;
        _collider.enabled = false;
        _rigid.simulated = false;
        _spriter.sortingOrder = 1;

        _animator.SetBool("Dead", true);
        GameManager.instance.kill++;
        GameManager.instance.GetExp();
    }

    public void ActiveOff()
    {
        gameObject.SetActive(false);
    }
}
