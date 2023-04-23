using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Intro = 0,
    BowlerSelection = 1
}

public class StateHandler : MonoBehaviour
{
    private IState[] states;
    private IState currentState;

    private void Start()
    {
        states = GetComponentsInChildren<IState>();
    }

    public void SetCurrentState(States state)
    {
        currentState = states[(int)state];
    }

    public void BeginCurrentState()
    {
        currentState.Begin(this);
    }

    public void EndCurrentState()
    {
        currentState.End();
    }
}
