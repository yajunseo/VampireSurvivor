using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;
    public float damage { get { return _damage; } }

    private int _per;
    public int per { get { return _per; } }

    public void Init(float damage, int per)
    {
        _damage = damage;
        _per = per;
    }

}
