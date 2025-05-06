using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject rankingParent;

    void Start()
    {
        GameManager.instance.Init();
        GameManager.instance.ClearPlayerRankingPrefabs(rankingParent);
        GameManager.instance.AddPlayerRankingPrefab(rankingParent);
    }


    private void OnDisable()
    {
        EventManager.Instance.UnregisterAllEvents();
    }

}
