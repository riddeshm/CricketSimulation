using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlSelection : MonoBehaviour, IState
{
    private StateHandler stateHandler;
    [SerializeField] private TextMeshProUGUI deliveryTypeText;
    [SerializeField] private GameObject cellContainer;
    private Cell[] cells;

    private void Start()
    {
        cells = cellContainer.GetComponentsInChildren<Cell>();
        foreach(Cell cell in cells)
        {
            cell.OnClicked += OnCellClicked;
        }
    }

    private void OnDestroy()
    {
        foreach (Cell cell in cells)
        {
            cell.OnClicked -= OnCellClicked;
        }
    }

    private void OnCellClicked(int number)
    {
        GameController.Instance.CurrentBowlType = number;
        deliveryTypeText.text = GameController.Instance.CurrentBowlerType.ToString() + " ball " + number;
        GameController.Instance.CurrentBall++;
        cellContainer.SetActive(false);
        stateHandler.EndCurrentState();
    }

    public void Begin(StateHandler _stateHandler)
    {
        stateHandler = _stateHandler;
        cellContainer.SetActive(true);
    }
    public void End()
    {
        stateHandler.SetCurrentState(States.BattingShotSelection);
        stateHandler.BeginCurrentState();
    }
}
