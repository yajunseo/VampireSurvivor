using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData _data;
    public int _level;
    public Weapon _weapon;

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
                break;
            case ItemData.ItemType.RANGE:
                break;
            case ItemData.ItemType.GLOVE:
                break;
            case ItemData.ItemType.SHOE:
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
