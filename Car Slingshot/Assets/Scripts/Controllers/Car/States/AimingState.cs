using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.States;

public class AimingState : State
{
    float carRotation = 0;

    Vector2 swipeStartPosition;

    Vector2 swipeCurrentPosition;
    Vector2 swipeDeltaPosition;

    float maxSwipeLenght;

    private void ChangeCarRotation(float newRotation)
    {
        carRotation = newRotation;
    }

    public AimingState()
    {
        EventManager.OnChangeCarRotation.AddListener(ChangeCarRotation);

        maxSwipeLenght = Screen.height / 2;
    }

    public override void Enter()
    {
        swipeStartPosition = Input.touches[0].position;
        swipeCurrentPosition = Input.touches[0].position;
    }

    public override void Update()
    {
        swipeCurrentPosition = Input.touches[0].position;
        swipeDeltaPosition = swipeStartPosition - swipeCurrentPosition;

        float power = swipeDeltaPosition.magnitude / maxSwipeLenght;
        if (power > 1) power = 1;

        float angle = Vector2.SignedAngle(-(swipeCurrentPosition - swipeStartPosition), Vector3.right);

        if (angle < 181 + carRotation && angle > 90 + carRotation) angle = -180 + carRotation;
        if (angle < 90 + carRotation && angle > 0 + carRotation) angle = 0 + carRotation;

        EventManager.ChangePower(power, angle); 
        
        if (Input.touches[0].phase == TouchPhase.Ended)
        {
            EventManager.MoveCar(power, angle);
        }
    }



    public override void Exit()
    {
        EventManager.UpdatePowerInfo(0);
    }
}
