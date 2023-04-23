using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BowlerType
{
    NONE = 0,
    SPIN = 1,
    FAST = 2
}

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    [SerializeField] private StateHandler stateHandler;
    [SerializeField] private TextMeshProUGUI deliveryTypeText;
    private int totalOvers;
    private int totalBallsPerOver;
    private int currentOver = 0;
    private int currentBall = 0;
    private int totalBatsmen;
    private int targetScore;

    private BowlerType currentBowlerType = BowlerType.NONE;
    private int currentBowlType = 0;


    public BowlerType CurrentBowlerType
    {
        get
        {
            return currentBowlerType;
        }
        set
        {
            currentBowlerType = value;
        }
    }

    public int CurrentOver
    {
        get
        {
            return currentOver;
        }
        set
        {
            currentOver = value;
        }
    }
    public int CurrentBall
    {
        get
        {
            return currentBall;
        }
        set
        {
            currentBall = value;
        }
    }

    public int CurrentBowlType
    {
        get
        {
            return currentBowlType;
        }
        set
        {
            currentBowlType = value;
        }
    }

    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
            _instance = null;
        }
        _instance = this;
    }

    private void Start()
    {
        stateHandler.SetCurrentState(States.Intro);
        stateHandler.BeginCurrentState();
    }

    public void UpdateDeliveryTypeText()
    {
        deliveryTypeText.text = currentBowlerType.ToString() + " ball " + currentBowlType;
    }
}
