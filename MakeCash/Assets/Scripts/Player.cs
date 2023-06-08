using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    List<Pipe> pipes = new List<Pipe>();
    public static event Action onAnyTouch;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (GameManager.Instance.State != GameManager.GameState.MakingMoney) { return; }

        if (Input.touchCount > 0)
        {
            onAnyTouch?.Invoke();
        }
    }
}
