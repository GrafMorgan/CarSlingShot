using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.States;

public class MovingState : State
{
    Rigidbody rigidbody;

    public MovingState(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public override void Update()
    {
        base.Update();

        Vector2 velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);
        if(velocity.magnitude <=0.1f)
        {
            EventManager.StopCar();
        }
    }
}
