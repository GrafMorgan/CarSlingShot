using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.States;

public class IdleState : State
{

    public IdleState()
    {
    }
    public override void Enter()
    {
    }

    public override void Update()
    {
        if (Input.touchCount>0 && Input.touches[0].position.y<Screen.height*9/10 && Input.touches[0].phase == TouchPhase.Began)
        {
            EventManager.FingerDown();
            
        }

    }

    public override void Exit()
    {

    }
}
