using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _prefabId;
    [SerializeField] private float _damage;
    [SerializeField] private int _count;
    [SerializeField] private float _speed;

    public int id { get { return _id; } }
    public float speed { get { return _speed; } set { _speed = value; } }

    float _timer;
    Player _player;

    private void Awake()
    {
        _player = GameManager.instance.player;
    }

    private void Update()
    {
        switch (_id)
        {
            case 0:
                transform.Rotate(Vector3.back * _speed * Time.deltaTime);

                break;
            default:
                _timer += Time.deltaTime;

                if(_timer > _speed)
                {
                    _timer = 0;
                    Fire();
                }

                break;
        }

        if(Input.GetButtonDown("Jump"))
        {
            LevelUp(10, 1);
        }
    }

    public void LevelUp(float damage, int count)
    {
        _damage = damage;
        _count += count;

        if (_id == 0)
            Batch();

        _player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    public void Init(ItemData data)
    {
        name = string.Format("Weapon{0}", data._itemId);
        transform.parent = _player.transform;
        transform.localPosition = Vector3.zero;

        _id = data._itemId;
        _damage = data._baseDamage;
        _count = data._baseCount;

        for(int i = 0; i < GameManager.instance.poolManger.prefabs.Length; i++)
        {
            if(data._projectile == GameManager.instance.poolManger.prefabs[i])
            {
                _prefabId = i;
                break;
            }
        }

        switch(_id)
        {
            case 0:
                _speed = 150;
                Batch();

                break;
            default:
                _speed = 0.4f;
                break;
        }

        _player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
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

            bullet.Init(_damage, -1, Vector3.zero);
        }
    }

    private void Fire()
    {
        Transform target = GameManager.instance.player.scanner.nearestTarget;

        if (target == null)
            return;

        Vector3 dir = (target.position - transform.position).normalized;

        Transform bullet = GameManager.instance.poolManger.Get(_prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(_damage, _count, dir);
    }
}
