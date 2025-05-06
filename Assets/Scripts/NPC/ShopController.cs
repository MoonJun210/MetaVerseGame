using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : InitPlayer
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI maxHpText;

    int upgradeSpeedCnt = 0;
    int upgradeMaxHpCnt = 0;

    private int[] upgradeGoldTable = { 10, 50, 100, 150, 200 };


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
    }

    public void TryUpgradeSpeed()
    {
        TryUpgrade(upgradeSpeedCnt, UpgradeType.Speed);
        upgradeSpeedCnt++; 
    }

    public void TryUpgradeMaxHp()
    {
        TryUpgrade(upgradeMaxHpCnt, UpgradeType.MaxHp);
        upgradeMaxHpCnt++;
    }

    public void TryUpgrade(int upgradeCount, UpgradeType type)
    {
        if (upgradeCount >= upgradeGoldTable.Length)
            return;

        int cost = upgradeGoldTable[upgradeCount];

        if (statController.Gold < cost)
            return;

        statController.Gold -= cost;

        switch (type)
        {
            case UpgradeType.Speed:
                statController.Speed += 0.2f;
                if(upgradeCount + 1 >= upgradeGoldTable.Length)
                {
                    speedText.text = $"More Speed /\nMAX";

                }
                else
                {
                    speedText.text = $"More Speed /\n{upgradeGoldTable[upgradeCount + 1]}G";

                }
                break;
            case UpgradeType.MaxHp:
                statController.MaxHp += 20;
                if (upgradeCount + 1 >= upgradeGoldTable.Length)
                {
                    maxHpText.text = $"More Hp /\nMAX";

                }
                else
                {
                    maxHpText.text = $"More Hp /\n{upgradeGoldTable[upgradeCount + 1]}G";

                }
                break;
        }

        EventManager.Instance.TriggerEvent("UpdateStat");

    }

}
