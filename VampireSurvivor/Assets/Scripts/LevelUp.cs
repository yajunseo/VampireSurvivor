using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField] RectTransform _rect;
    [SerializeField] Item[] _items;

    public void Show()
    {
        Next();
        _rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        _rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Select(int index)
    {
        _items[index].OnClick();
    }

    void Next()
    {
        foreach (var item in _items)
        {
            item.gameObject.SetActive(false);
        }

        int[] rand = new int[3];
        while(true)
        {
            rand[0] = Random.Range(0, _items.Length);
            rand[1] = Random.Range(0, _items.Length);
            rand[2] = Random.Range(0, _items.Length);

            if (rand[0] != rand[1]
                && rand[1] != rand[2]
                && rand[2] != rand[0])
                break;
        }

        for (int i = 0; i < rand.Length; i++)
        {
            Item randItem = _items[rand[i]];

            if (randItem._level >= randItem._data._damages.Length)
            {
                _items[_items.Length - 1].gameObject.SetActive(true);
            }

            else
            {
                randItem.gameObject.SetActive(true);
            }
        }
    }
}
