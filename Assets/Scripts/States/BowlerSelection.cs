using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlerSelection : MonoBehaviour, IState
{
    private StateHandler stateHandler;
    [SerializeField] GameObject bowlerSelectionScreen;
    public void Begin(StateHandler _stateHandler)
    {
        stateHandler = _stateHandler;
        bowlerSelectionScreen.SetActive(true);
    }

    public void SelectedBowler(int bowlerType)
    {
        bowlerSelectionScreen.SetActive(false);
        GameController.Instance.CurrentBowlerType = (BowlerType)bowlerType;
        GameController.Instance.CurrentOver++;
        GameController.Instance.CurrentBall = 0;
        stateHandler.EndCurrentState();
    }

    public void End()
    {
        stateHandler.SetCurrentState(States.BowlSelection);
        stateHandler.BeginCurrentState();
    }
}
