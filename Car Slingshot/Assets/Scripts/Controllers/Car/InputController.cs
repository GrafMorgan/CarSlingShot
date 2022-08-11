using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.States;

public class InputController : MonoBehaviour
{
    StateMachine stateMachine;

    IdleState idleState;
    AimingState aimingState;
    MovingState movingState;

    bool isPause;

    private void OnFingerDown()
    {
        stateMachine.ChangeState(aimingState);
    }

    private void OnCarMove(float power, float angle)
    {
        stateMachine.ChangeState(movingState);
    }

    private void PauseStateChange(bool isPause)
    {
        this.isPause = isPause;
    }
    private void OnCarStop()
    {
        stateMachine.ChangeState(idleState);
    }

    void Start()
    {
        isPause = false;

        stateMachine = new StateMachine();

        idleState = new IdleState();
        aimingState = new AimingState();
        movingState = new MovingState(GetComponent<Rigidbody>());

        stateMachine.Initialize(idleState);

        EventManager.OnFingerDown.AddListener(OnFingerDown);
        EventManager.OnCarMove.AddListener(OnCarMove);
        EventManager.OnPauseStateChange.AddListener(PauseStateChange);
        EventManager.OnCarStop.AddListener(OnCarStop);
    }

    void Update()
    {
        if (!isPause)
        {
            stateMachine.currentState.Update();
        }
    }
}
