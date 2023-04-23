using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlSelection : MonoBehaviour, IState
{
    private StateHandler stateHandler;
    [SerializeField] GameObject cells;

    public void Begin(StateHandler _stateHandler)
    {
        stateHandler = _stateHandler;
    }
    public void End()
    {
        
    }
}
