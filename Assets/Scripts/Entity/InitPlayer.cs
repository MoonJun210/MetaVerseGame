using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class InitPlayer : MonoBehaviour
{
    protected BaseController baseController;

    protected virtual void Awake()
    {
        EventManager.Instance.RegisterEvent<GameObject>("OnPlayerSpawned", OnPlayerSpawned);
    }

    private void OnPlayerSpawned(GameObject playerObj)
    {
        baseController = playerObj.GetComponent<BaseController>();
    }
}
