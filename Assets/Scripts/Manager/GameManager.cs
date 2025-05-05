using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;
    private GameObject player;

    private void Awake()
    {
        instance = this;

      
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        EventManager.Instance.TriggerEvent("OnPlayerSpawned", player);
        EventManager.Instance.TriggerEvent("UpdateStat");
        EventManager.Instance.TriggerEvent("InitNpc", player);
        EventManager.Instance.TriggerEvent("InitCamera", player);
    }

    private void OnDisable()
    {
        EventManager.Instance.UnregisterAllEvents();
    }
}
