using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Action<int> OnClicked;
    [SerializeField] private int number;

    private void OnMouseDown()
    {
        OnClicked?.Invoke(number);
    }
}
