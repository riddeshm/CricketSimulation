using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour, IState
{
    private StateHandler stateHandler;
    [SerializeField] GameObject resultScreen;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI ballsRemaining;
    [SerializeField] TextMeshProUGUI deliveryType;
    [SerializeField] GameObject restartButton;
    private WaitForSeconds waitForSeconds = new WaitForSeconds(1.5f);

    private int totalBallsBowled = 0;

    public void Begin(StateHandler _stateHandler)
    {
        stateHandler = _stateHandler;
        resultScreen.SetActive(true);
        totalBallsBowled = ((GameController.Instance.CurrentOver - 1) * GameController.Instance.TotalBallsPerOver) + GameController.Instance.CurrentBall;
        StartCoroutine(DisplayResultsAndUpdateScore());
    }

    private IEnumerator DisplayResultsAndUpdateScore()
    {
        if(!GameController.Instance.IsMissed && !GameController.Instance.IsOut)
        {
            resultText.text = GameController.Instance.CurrentScore + " RUNS";
            GameController.Instance.TotalScore += GameController.Instance.CurrentScore;
        }
        else
        {
            if(GameController.Instance.IsOut)
            {
                resultText.text = "OUT";
                GameController.Instance.IsOut = false;
                GameController.Instance.TotalBatsmen--;
            }
            else if(GameController.Instance.IsMissed)
            {
                resultText.text = "MISSED";
                GameController.Instance.IsMissed = false;
            }
        }
        yield return waitForSeconds;
        score.text = GameController.Instance.TotalScore.ToString();
        ballsRemaining.text = (GameController.Instance.TotalBalls - totalBallsBowled).ToString();
        stateHandler.EndCurrentState();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void End()
    {
        deliveryType.text = "";
        Debug.Log("GameController.Instance.CurrentBall " + GameController.Instance.CurrentBall);
        Debug.Log("GameController.Instance.CurrentOver " + GameController.Instance.CurrentOver);
        
        
        Debug.Log("totalBallsBowled " + totalBallsBowled);
        if (GameController.Instance.TotalBatsmen == 0)
        {
            resultText.text = "Bowlers Win!";
            restartButton.SetActive(true);
            return;
        }
        if(GameController.Instance.TotalScore >= GameController.Instance.TargetScore)
        {
            resultText.text = "Batsman Win!";
            restartButton.SetActive(true);
            return;
        }
        if (totalBallsBowled == GameController.Instance.TotalBalls)
        {
            if(GameController.Instance.TotalScore == GameController.Instance.TargetScore - 1)
            {
                resultText.text = "Draw!";
                restartButton.SetActive(true);
                return;
            }
            else if (GameController.Instance.TotalScore < GameController.Instance.TargetScore)
            {
                resultText.text = "Bowlers Win!";
                restartButton.SetActive(true);
                return;
            }
        }
        resultScreen.SetActive(false);
        if (GameController.Instance.CurrentBall == GameController.Instance.TotalBallsPerOver)
        {
            stateHandler.SetCurrentState(States.BowlerSelection);
            stateHandler.BeginCurrentState();
            return;
        }
        else if (GameController.Instance.CurrentBall < GameController.Instance.TotalBallsPerOver)
        {
            stateHandler.SetCurrentState(States.BowlSelection);
            stateHandler.BeginCurrentState();
            return;
        }
    }
}
