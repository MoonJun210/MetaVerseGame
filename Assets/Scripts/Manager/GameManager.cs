using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;
    public GameObject rankingPrefab;
    private GameObject player;

    public Dictionary<int, MiniGameResult> miniGameResults = new();


    private void Awake()
    {
        // ½Ì±ÛÅæ ¼³Á¤
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // ¾ÀÀÌ ¹Ù²î¾îµµ ÆÄ±«µÇÁö ¾ÊÀ½
    }

    private void Start()
    {
       
    }

    public void Init()
    {
     
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        EventManager.Instance.TriggerEvent("OnPlayerSpawned", player);
        EventManager.Instance.TriggerEvent("UpdateStat");
        EventManager.Instance.TriggerEvent("InitNpc", player);
        EventManager.Instance.TriggerEvent("InitCamera", player);
    }

    public void SaveMiniGameResult(int gameId, MiniGameResult result)
    {
        if(miniGameResults.TryGetValue(gameId, out MiniGameResult existResult))
        {
            if(result.Score > existResult.Score)
            {
                miniGameResults[gameId] = result;
            }
        }
        else
        {
            miniGameResults[gameId] = result;
        }
    }

    public MiniGameResult GetMiniGameResult(int gameId)
    {
        return miniGameResults.ContainsKey(gameId) ? miniGameResults[gameId] : null;
    }

    public void AddPlayerRankingPrefab(GameObject parent)
    {
        GameObject playerRanking = Instantiate(rankingPrefab, parent.transform);

        TextMeshProUGUI nicknameText = playerRanking.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI score1Text = playerRanking.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI score2Text = playerRanking.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        nicknameText.text = "Player";
        MiniGameResult r = GetMiniGameResult(0);
        if(r == null)
        {
            score1Text.text = "0";
        }
        else
        {
            score1Text.text = r.Score.ToString();
        }

        r = GetMiniGameResult(1);
        if (r == null)
        {
            score2Text.text = "0";
        }
        else
        {
            score2Text.text = r.Score.ToString();
        }
    }

    public void ClearPlayerRankingPrefabs(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
