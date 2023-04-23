using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Intro = 0,
    BowlerSelection = 1,
    BowlSelection = 2
}

public class StateHandler : MonoBehaviour
{
    private IState[] states;
    private IState currentState;

    private void Awake()
    {
        states = GetComponentsInChildren<IState>();
        Debug.Log(states.Length);
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
