using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : InitPlayer
{

    public GameObject[] charImgs;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI goldText;

    protected override void Awake()
    {
        base.Awake();
        EventManager.Instance.RegisterEvent("UpdateStat", UpdateStat);
    }


    private void UpdateStat()
    {
        hpText.text = GameManager.instance.playerStatData.MaxHp.ToString();
        speedText.text = GameManager.instance.playerStatData.Speed.ToString("F1");
        goldText.text = GameManager.instance.playerStatData.Gold.ToString();
    }

    public void Plus_ChangeSprite()
    {
       
        EventManager.Instance.TriggerEvent("ChangeSprite", baseController.CharNum + 1);
        ChangeCharImgs(baseController.CharNum);
    }

    public void Minus_ChangeSprite()
    {
        EventManager.Instance.TriggerEvent("ChangeSprite", baseController.CharNum - 1);
        ChangeCharImgs(baseController.CharNum);

    }

    void ChangeCharImgs(int num)
    {
        for(int i = 0; i< charImgs.Length; i++)
        {
            charImgs[i].SetActive(false);
        }

        charImgs[num].SetActive(true);
    }

}
