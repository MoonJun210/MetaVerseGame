using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;
    float offsetX;
    float offsetY;

    private void Awake()
    {
        EventManager.Instance.RegisterEvent<GameObject>("InitCamera", InitCamera);
    }

    void InitCamera(GameObject player)
    {
        target = player.transform;
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        transform.position = pos;
    }

}
