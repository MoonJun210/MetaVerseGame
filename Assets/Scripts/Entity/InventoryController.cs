using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private BaseController baseController;
    private StatController statController;


    public GameObject[] charImgs;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI goldText;

    private void Awake()
    {
        EventManager.Instance.RegisterEvent<GameObject>("OnPlayerSpawned", OnPlayerSpawned);
        EventManager.Instance.RegisterEvent("UpdateStat", UpdateStat);

    }

    private void OnPlayerSpawned(GameObject playerObj)
    {
        baseController = playerObj.GetComponent<BaseController>();
        statController = playerObj.GetComponent<StatController>();
    }

    private void UpdateStat()
    {
        hpText.text = statController.MaxHp.ToString();
        speedText.text = statController.Speed.ToString();
        goldText.text = statController.Gold.ToString();
    }

    public void Plus_ChangeSprite()
    {
        if(baseController == null)
        {
            Debug.Log("문제발생");
        }
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
