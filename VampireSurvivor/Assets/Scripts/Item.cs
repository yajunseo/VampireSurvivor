using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData _data;
    [NonSerialized] public int _level;
    [NonSerialized] public Weapon _weapon;
    [NonSerialized] public Gear _gear;

    [SerializeField] Image _icon;
    [SerializeField] Text _textLevel;
    [SerializeField] Text _textName;
    [SerializeField] Text _textDesc;
    [SerializeField] Button _itemBtn;

    private void Awake()
    {
        _icon.sprite = _data._itemIcon;
        _textName.text = _data._itemName;
    }

    private void OnEnable()
    {
        _textLevel.text = string.Format("Lv.{0}", _level + 1);
        switch (_data.itemType)
        {
            case ItemData.ItemType.MELEE:
            case ItemData.ItemType.RANGE:
                _textDesc.text = string.Format(_data._itemDesc, _data._damages[_level] * 100, _data.counts[_level]);
                break;
            case ItemData.ItemType.GLOVE:
            case ItemData.ItemType.SHOE:
                _textDesc.text = string.Format(_data._itemDesc, _data._damages[_level] * 100);
                break;
            default:
                _textDesc.text = string.Format(_data._itemDesc);
                break;
        }
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
                _level++;
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
                _level++;
                break;
            case ItemData.ItemType.HEAL:
                break;
        }

        if(_level >= _data._damages.Length)
        {
            _itemBtn.interactable = false;
        }
    }
}
