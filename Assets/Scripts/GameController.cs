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
    [SerializeField] private TextMeshProUGUI ballsRemainingText;
    private int totalOvers = 5;
    private int totalBallsPerOver = 6;
    private int currentOver = 0;
    private int currentBall = 0;
    private int totalBatsmen = 5;
    private int targetScore = 60;
    private int totalScore = 0;
    private int currentScore = 0;
    private bool isOut = false;
    private bool isMissed = false;

    private BowlerType currentBowlerType = BowlerType.NONE;
    private int currentBowlType = 0;

    public int TargetScore
    {
        get
        {
            return targetScore;
        }
    }

    public int TotalBalls
    {
        get
        {
            return totalOvers * totalBallsPerOver;
        }
    }

    public int TotalBallsPerOver
    {
        get
        {
            return totalBallsPerOver;
        }
    }

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

    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
        }
    }

    public bool IsOut
    {
        get
        {
            return isOut;
        }
        set
        {
            isOut = value;
        }
    }

    public bool IsMissed
    {
        get
        {
            return isMissed;
        }
        set
        {
            isMissed = value;
        }
    }

    public int TotalBatsmen
    {
        get
        {
            return totalBatsmen;
        }
        set
        {
            totalBatsmen = value;
        }
    }

    public int TotalScore
    {
        get
        {
            return totalScore;
        }
        set
        {
            totalScore = value;
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

        ballsRemainingText.text = TotalBalls.ToString();
    }
}
