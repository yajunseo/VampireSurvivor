using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData _data;
    public int _level;
    public Weapon _weapon;
    public Gear _gear;

    [SerializeField] Image _icon;
    [SerializeField] Text _textLevel;
    [SerializeField] Button _itemBtn;

    private void Awake()
    {
        _icon.sprite = _data._itemIcon;
    }

    private void LateUpdate()
    {
        _textLevel.text = string.Format("Lv.{0}", _level + 1);
    }

    public void OnClick()
    {
        switch (_data.itemType)
        {
            case ItemData.ItemType.MELEE:
            case ItemData.ItemType.RANGE:
                if (_level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    _weapon = newWeapon.AddComponent<Weapon>();
                    _weapon.Init(_data);
                }
                else
                {
                    float nextDamage = _data._baseDamage + (1 + _data._damages[_level]);
                    int nextCount = _data.counts[_level];

                    _weapon.LevelUp(nextDamage, nextCount);
                }
                break;
            case ItemData.ItemType.GLOVE:
            case ItemData.ItemType.SHOE:
                if (_level == 0)
                {
                    GameObject newGear = new GameObject();
                    _gear = newGear.AddComponent<Gear>();
                    _gear.Init(_data);
                }
                else
                {
                    float nextRate = _data._damages[_level];
                    _gear.LevelUp(nextRate);
                }
                break;
            case ItemData.ItemType.HEAL:
                break;
        }

        _level++;

        if(_level >= _data._damages.Length)
        {
            _itemBtn.interactable = false;
        }
    }
}
