using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;



public class NPCController : BaseController
{
    private Transform target;
    private InteractHandler interactHandler;
    public GameObject questionMark;

    public NPCType npcType;


    protected override void Awake()
    {
        base.Awake();
        EventManager.Instance.RegisterEvent<GameObject>("InitNpc", InitNpc);
    }

    void InitNpc(GameObject player)
    {
        target = player.transform;
        Vector2 direction = DirectionToTarget();
        lookDirection = direction;

        interactHandler = target.gameObject.GetComponent<InteractHandler>();
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

            questionMark.SetActive(true);

            interactHandler.IsNPCTrigger = true;
            interactHandler.NPCType = npcType;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            questionMark.SetActive(false);
            interactHandler.IsNPCTrigger = false;
            interactHandler.NPCType = NPCType.None;
        }
    }


}
