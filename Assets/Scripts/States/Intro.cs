using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour, IState
{
    [SerializeField] private GameObject introScreen;
    private StateHandler stateHandler;
    public void Begin(StateHandler _stateHandler)
    {
        stateHandler = _stateHandler;
        introScreen.SetActive(true);
    }

    public void OnStartClicked()
    {
        introScreen.SetActive(false);
        stateHandler.EndCurrentState();
    }

    public void End()
    {
        stateHandler.SetCurrentState(States.BowlerSelection);
        stateHandler.BeginCurrentState();
    }
}
