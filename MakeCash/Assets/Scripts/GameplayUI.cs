using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Slider popupSlider;
    [SerializeField] private Slider burnSlider;
    [SerializeField] private Button freezeButton;
    [SerializeField] private Button speedUpButton;
    [SerializeField] private Button addPipeButton;
    [SerializeField] private Button increaseIncomeButton;
    [SerializeField] private Button gpuIncreaserButton;
    [SerializeField] private Slider isnewGPUReadySlider;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button vibrationButton;


    private void Start()
    {
     //   TouchManager.onAnyTouch += GamePlayUI_OnTouch;
        freezeButton.onClick.AddListener(() => FreezeButtonSequence());
    }
    private void OnDestroy()
    {
     //   TouchManager.onAnyTouch -= GamePlayUI_OnTouch;
    }
    private void Update()
    {
        burnSlider.value =Player.Instance.GetBurnDegree();
    }
    //private void GamePlayUI_OnTouch()
    //{
    //}
    private void FreezeButtonSequence()
    {
        Player.Instance.FreezingGpu();
    }
}
