using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    private InteractHandler interactHandler;
    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
        interactHandler = GetComponent<InteractHandler>();
    }

    protected override void HandleAction()
    {
    

    }

    void OnMove(InputValue inputValue)
    {
        if(interactHandler.IsConversation)
        {
            return;
        }
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
    
    void OnLook(InputValue inputValue)
    {
        if (interactHandler.IsConversation)
        {
            return;
        }
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnFire()
    {

    }
}
