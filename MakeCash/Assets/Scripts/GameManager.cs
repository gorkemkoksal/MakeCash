using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State;

    public static event Action<GameState> onAnyStateChanged;
    public enum GameState
    {
        MakingMoney,
        Shop,
        Popup
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateGameState(GameState.MakingMoney);
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (State)
        {
            case GameState.MakingMoney:
                HandleMakingMoney();
                break;
            case GameState.Shop:
                HandleShop();
                break;
            case (GameState.Popup):
                HandlePopup();
                break;
        }
        onAnyStateChanged?.Invoke(newState);
    }
    private void HandleMakingMoney()
    {
        throw new NotImplementedException();
    }

    private void HandleShop()
    {
        throw new NotImplementedException();
    }

    private void HandlePopup()
    {
        throw new NotImplementedException();
    }

}
