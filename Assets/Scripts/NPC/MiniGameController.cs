using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : InitPlayer
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void MiniGame_1()
    {
        SceneManager.LoadScene("MiniGame_1");
    }

    public void MiniGame_2()
    {
        SceneManager.LoadScene("MiniGame_2");

    }
}
