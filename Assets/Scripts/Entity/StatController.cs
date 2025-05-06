using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private int maxHp = 100;
    private int gold = 10000;
    private float speed = 5.0f;
    private float rideSpeed = 10f;


    public int MaxHp
    {
        get => maxHp;
        set => maxHp = value;
    }
    public int Gold
    {
        get => gold;
        set => gold = value;
    }
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    public float RideSpeed
    {
        get => rideSpeed;
        set => rideSpeed = value;
    }


}
