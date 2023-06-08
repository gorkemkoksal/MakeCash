using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
  //  [SerializeField] private GameObject popup;
    private void Awake()
    {
        GameManager.onAnyStateChanged += MenuManager_OnStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.onAnyStateChanged -= MenuManager_OnStateChanged;
    }
    private void MenuManager_OnStateChanged(GameManager.GameState state)
    {
        shopCanvas.SetActive(state==GameManager.GameState.Shop);
    //    popup.SetActive(state==GameManager.GameState.Popup);
    }
}
