using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattingShotSelection : MonoBehaviour, IState
{
    private StateHandler stateHandler;
    [SerializeField] private GameObject battingShotSelectionScreen;
    private Dictionary<int, float> shotProbability = new Dictionary<int, float>(){
            { 0, 0.9f },
            { 1, 0.85f },
            { 2, 0.6f },
            { 4, 0.35f },
            { 6, 0.2f }
        };

    public void Begin(StateHandler _stateHandler)
    {
        stateHandler = _stateHandler;
        battingShotSelectionScreen.SetActive(true);
    }

    public void OnBattingShotSelected(int shotNumber)
    {
        int hasScoredRuns = GetRandomValue(0, 1, shotProbability[shotNumber]);
        if(hasScoredRuns == 1)
        {
            GameController.Instance.CurrentScore = shotNumber;
        }
        else
        {
            int isSafe = GetRandomValue(0, 1, 0.5f);
            if(isSafe == 1)
            {
                GameController.Instance.CurrentScore = 0;
                GameController.Instance.IsMissed = true;
            }
            else
            {
                GameController.Instance.CurrentScore = 0;
                GameController.Instance.IsOut = true;
            }
        }
        battingShotSelectionScreen.SetActive(false);
        stateHandler.EndCurrentState();
    }


    private int GetRandomValue(int min, int max, float probability)
    {
        float randomNum = Random.value;
        if (randomNum <= probability)
            return max;
        else 
            return min;
    }

    public void End()
    {
        stateHandler.SetCurrentState(States.Result);
        stateHandler.BeginCurrentState();
    }
}
