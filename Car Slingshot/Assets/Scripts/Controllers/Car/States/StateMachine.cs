using System.Collections;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class StateMachine 
    {
        public State currentState { private set; get; }

        public void Initialize(State startState)
        {
            currentState = startState;
            currentState.Enter();
        }

        public void ChangeState(State newState)
        {
            currentState.Exit();
            currentState = newState;
            newState.Enter();
        }


    }
}