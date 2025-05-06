using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractHandler : MonoBehaviour
{
    private GameObject npcUI;
    private GameObject[] npcUIs;
    private Button[] closeBtns;
    public bool IsNPCTrigger { get; set; }
    public bool IsConversation { get; set; }
    public NPCType NPCType { get; set; }

    private void Awake()
    {
        Init();
    }

    // npcUI √ ±‚»≠
    void Init()
    {
        npcUI = GameObject.Find("NpcUI");

        int childCount = npcUI.transform.childCount;
        npcUIs = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            npcUIs[i] = npcUI.transform.GetChild(i).GetChild(0).gameObject;
        }

        closeBtns = npcUI.GetComponentsInChildren<Button>(true);
        foreach (Button btn in closeBtns)
        {
            if (btn.CompareTag("CloseBtn"))
            {
                btn.onClick.AddListener(EndConversation);
            }
        }
    }

    void OnConversation(InputValue inputValue)
    {
        if (IsNPCTrigger && inputValue.isPressed)
        {
            IsConversation = true;
            switch (NPCType)
            {
                case NPCType.None:
                    break;
                case NPCType.Shop:
                    npcUIs[(int)NPCType.Shop - 1].SetActive(true);
                    break;
                case NPCType.Inventory:
                    npcUIs[(int)NPCType.Inventory - 1].SetActive(true);
                    break;
                case NPCType.MiniGame:
                    npcUIs[(int)NPCType.MiniGame - 1].SetActive(true);
                    break;
                case NPCType.Ranking:
                    npcUIs[(int)NPCType.Ranking - 1].SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void EndConversation()
    {
        IsConversation = false;
        for (int i = 0; i < npcUIs.Length; i++)
        {
            npcUIs[i].SetActive(false);
        }

    }
}
