using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType _type;
    public float _rate;

    public void Init(ItemData data)
    {
        name = string.Format("Gear{0}", data._itemId);
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        _type = data.itemType;
        _rate = data._damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        _rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
        switch (_type)
        {
            case ItemData.ItemType.GLOVE:
                RateUp();
                break;
            case ItemData.ItemType.SHOE:
                SpeedUp();
                break;
        }
    }

    private void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponents<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * _rate);
                    break;
                case 1:
                    weapon.speed = 0.5f * (1f - _rate);
                    break;
            }

        }
    }

    private void SpeedUp()
    {
        float speed = 3;
        GameManager.instance.player.speed = speed + speed * _rate;
    }
}
