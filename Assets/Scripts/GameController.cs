using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    [SerializeField] private StateHandler stateHandler;

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
}
