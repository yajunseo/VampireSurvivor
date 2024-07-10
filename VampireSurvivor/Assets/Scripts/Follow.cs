using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] RectTransform _rect;

    private void FixedUpdate()
    {
        _rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
}
