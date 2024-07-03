using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _prefabId;
    [SerializeField] private float _damage;
    [SerializeField] private int _count;
    [SerializeField] private int _speed;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (_id)
        {
            case 0:
                transform.Rotate(Vector3.back * _speed * Time.deltaTime);

                break;
            default:
                break;
        }

        if(Input.GetButtonDown("Jump"))
        {
            LevelUp(50, 3);
        }
    }

    public void LevelUp(float damage, int count)
    {
        _damage = damage;
        _count += count;

        if (_id == 0)
            Batch();
    }

    public void Init()
    {
        switch(_id)
        {
            case 0:
                _speed = 150;
                Batch();

                break;
            default:
                break;
        }
    }

    private void Batch()
    {
        for(int i = 0; i < _count; i++)
        {
            Bullet bullet;
            
            if(i < transform.childCount)
            {
                bullet = transform.GetChild(i).GetComponent<Bullet>();
            }

            else
            {
                bullet = GameManager.instance.poolManger.Get(_prefabId).GetComponent<Bullet>();
                bullet.transform.parent = transform;
            }

            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / _count;
            bullet.transform.Rotate(rotVec);
            bullet.transform.Translate(bullet.transform.up * 1.5f, Space.World);

            bullet.Init(_damage, -1);
        }
    }
}
