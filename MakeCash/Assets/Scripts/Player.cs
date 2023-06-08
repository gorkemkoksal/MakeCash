using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float freezeDuration = 10f;
    [SerializeField] private float freezeBurningAmount = 0.1f;
    [SerializeField] private float gpuBurningSpeed = 0.15f;
    [SerializeField] private float gpuCoolingSpeed = 0.05f;
    private float burnDegree;
    private bool isFreezed;
    private float freezeCounter;

    List<Pipe> pipes = new List<Pipe>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TouchManager.onAnyTouch += Player_OnAnyTouch;
        StartCoroutine(BurningGPU());
    }

    void Update()
    {

        if (GameManager.Instance.State != GameManager.GameState.MakingMoney) { return; }
        //if different state return 

        GpuBurningSpeedSetter();
    }
    private void Player_OnAnyTouch()
    {
        burnDegree += gpuBurningSpeed;
    }
    IEnumerator BurningGPU()
    {
        while (GameManager.Instance.State == GameManager.GameState.MakingMoney)
        {
            burnDegree = Mathf.Max(0, burnDegree - gpuCoolingSpeed);
            yield return new WaitForSeconds(0.1f);
        }
    }
    // public void SetIsTouched(bool isTouched) => this.isTouched = isTouched;
    public void FreezingGpu()
    {
        isFreezed = true;
        gpuBurningSpeed -= freezeBurningAmount;
    }
    private void GpuBurningSpeedSetter()
    {
        if (!isFreezed) { return; }

        else if (isFreezed && freezeCounter < freezeDuration)
        {
            freezeCounter += Time.deltaTime;
        }
        else if (isFreezed && freezeCounter > freezeDuration)
        {
            freezeCounter = 0;
            gpuBurningSpeed += freezeBurningAmount;
            isFreezed = false;
        }
    }
    public float GetBurnDegree() => burnDegree;

}
