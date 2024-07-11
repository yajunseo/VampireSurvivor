using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        MELEE,
        RANGE,
        GLOVE,
        SHOE,
        HEAL
    }

    [Header("Main Info")]
    public ItemType itemType;
    public int _itemId;
    public string _itemName;
    public string _itemDesc;
    public Sprite _itemIcon;

    [Header("Level Data")]
    public float _baseDamage;
    public int _baseCount;
    public float[] _damages;
    public int[] counts;

    [Header("Weapon")]
    public GameObject _projectile;
}
