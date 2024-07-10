using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        EXP,
        LEVEL,
        KILL,
        TIME,
        HEALTH
    }

    public InfoType _type;

    private Text _myText;
    private Slider _mySlider;

    private void Awake()
    {
        _myText = GetComponent<Text>();
        _mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (_type)
        {
            case InfoType.EXP:
                float curExp = GameManager.instance.exp;
                float nextExp = GameManager.instance.nextExp[GameManager.instance.level];
                _mySlider.value = curExp / nextExp;
                break;

            case InfoType.LEVEL:
                _myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
                break;

            case InfoType.KILL:
                _myText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;

            case InfoType.TIME:
                float remainTime = GameManager.MAX_GAME_TIME - GameManager.instance.gameTime;
                int minute = Mathf.FloorToInt(remainTime / 60);
                int second = Mathf.FloorToInt(remainTime % 60);
                _myText.text = string.Format("{0:D2}:{1:D2}", minute, second);
                break;

            case InfoType.HEALTH:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                _mySlider.value = curHealth / maxHealth;
                break;
        }
    }
}
