using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NPCController : BaseController
{
    private Transform target;

    protected override void Start()
    {
        base.Start();
        target = GameManager.instance.player.transform;
        Vector2 direction = DirectionToTarget();
        lookDirection = direction;
    }

    protected override void HandleAction()
    {
        base.HandleAction();

        if(movementDirection == null)
        {
            movementDirection = Vector2.zero;
        }



    }

    protected override void FixedUpdate()
    {
       
    }

    protected Vector2 DirectionToTarget()
    {
        return (target.position - transform.position).normalized;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            target = collision.transform;
            Vector2 direction = DirectionToTarget();
            lookDirection = direction;
        }
    }

}
