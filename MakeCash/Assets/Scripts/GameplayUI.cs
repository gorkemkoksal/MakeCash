using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Slider popupSLider;
    [SerializeField] private Slider burnSlider;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button freezeButton;
    [SerializeField] private float freezeBurningSpeed=0.1f;
    [SerializeField] private Button speedUpButton;
    [SerializeField] private Button addPipeButton;
    [SerializeField] private Button increaseIncomeButton;
    [SerializeField] private Button gpuIncreaserButton;
    [SerializeField] private Slider isnewGPUReadySlider;
    [SerializeField] private float gpuBurningSpeed = 0.15f;
    [SerializeField] private float gpuCoolingSpeed = 0.3f;

    private void Start()
    {
        Player.onAnyTouch += GamePlayUI_OnTouch;
        freezeButton.onClick.AddListener(() => FreezeButtonSequence(freezeBurningSpeed));
    }
    private void Update()
    {
        if (GameManager.Instance.State != GameManager.GameState.MakingMoney) { return; }

        burnSlider.value = Mathf.Max(0, burnSlider.value - gpuCoolingSpeed) * Time.deltaTime;
    }
    private void GamePlayUI_OnTouch()
    {
        burnSlider.value += gpuBurningSpeed;
    }
    private void FreezeButtonSequence(float BurningValue)
    {
        gpuBurningSpeed = BurningValue;
    }

}
