using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    public float damage { get { return _damage; } }

    [SerializeField]
    private int _per;
    public int per { get { return _per; } }

    [SerializeField]
    private Rigidbody2D _rigid;
    public Rigidbody2D rigid { get { return _rigid; } }

    public void Init(float damage, int per, Vector3 dir)
    {
        _damage = damage;
        _per = per;

        if (per > -1)
        {
            _rigid.velocity = dir * 15f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || _per == -1)
            return;

        _per--;

        if(_per == -1)
        {
            _rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
