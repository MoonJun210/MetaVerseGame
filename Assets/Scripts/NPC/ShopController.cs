using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : InitPlayer
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI maxHpText;



    private int[] upgradeGoldTable = { 10, 50, 100, 150, 200 };


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        UpdateUpgradeUI();
    }

    public void TryUpgradeSpeed()
    {
        TryUpgrade(UpgradeType.Speed);
    }

    public void TryUpgradeMaxHp()
    {
        TryUpgrade(UpgradeType.MaxHp);
    }

    public void TryUpgrade(UpgradeType type)
    {
        int count;
        switch (type)
        {
            case UpgradeType.Speed:
                count = GameManager.instance.playerStatData.SpeedUpgradeCount;
                break;
            case UpgradeType.MaxHp:
                count = GameManager.instance.playerStatData.MaxHpUpgradeCount;
                break;
            default:
                count = 0;
                break;
        }

        if (count >= upgradeGoldTable.Length)
            return;

        int cost = upgradeGoldTable[count];

        if (GameManager.instance.playerStatData.Gold < cost)
            return;

        GameManager.instance.playerStatData.Gold -= cost;

        switch (type)
        {
            case UpgradeType.Speed:
                GameManager.instance.playerStatData.Speed += 0.5f;
                GameManager.instance.playerStatData.SpeedUpgradeCount++;
                break;
            case UpgradeType.MaxHp:
                GameManager.instance.playerStatData.MaxHp += 20;
                GameManager.instance.playerStatData.MaxHpUpgradeCount++;
                break;
        }

        EventManager.Instance.TriggerEvent("UpdateStat");
        UpdateUpgradeUI();
    }

    public void UpdateUpgradeUI()
    {
        int speedCount = GameManager.instance.playerStatData.SpeedUpgradeCount;
        int hpCount = GameManager.instance.playerStatData.MaxHpUpgradeCount;

        if (speedCount >= upgradeGoldTable.Length)
        {
            speedText.text = "More Speed /\nMAX";

        }
        else
        {
            speedText.text = $"More Speed /\n{upgradeGoldTable[speedCount]}G";
        }

        if (hpCount >= upgradeGoldTable.Length)
        {
            maxHpText.text = "More Hp /\nMAX";
        }
        else
        {
            maxHpText.text = $"More Hp /\n{upgradeGoldTable[hpCount]}G";
        }
    }


}
