using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;
    public GameObject rankingPrefab;
    private GameObject player;

    public StatData playerStatData;

    public Dictionary<int, MiniGameResult> miniGameResults = new();


    private void Awake()
    {
        // ΩÃ±€≈Ê º≥¡§
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        playerStatData = new StatData();
        DontDestroyOnLoad(gameObject); // æ¿¿Ã πŸ≤ÓæÓµµ ∆ƒ±´µ«¡ˆ æ ¿Ω
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
        string key = $"MiniGameResult_{gameId}";

        if (miniGameResults.TryGetValue(gameId, out MiniGameResult existResult))
        {
            if (result.Score > existResult.Score)
            {
                miniGameResults[gameId] = result;
                PlayerPrefs.SetInt(key, result.Score);
            }
        }
        else
        {
            miniGameResults[gameId] = result;
            PlayerPrefs.SetInt(key, result.Score);
        }

        PlayerPrefs.Save(); // ¿˙¿Â
    }


    public MiniGameResult GetMiniGameResult(int gameId)
    {
        if (miniGameResults.ContainsKey(gameId))
            return miniGameResults[gameId];

        string key = $"MiniGameResult_{gameId}";
        if (PlayerPrefs.HasKey(key))
        {
            int savedScore = PlayerPrefs.GetInt(key);
            MiniGameResult loaded = new MiniGameResult
            {
                MiniGameId = gameId,
                Score = savedScore
            };
            miniGameResults[gameId] = loaded;
            return loaded;
        }

        return null;
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
