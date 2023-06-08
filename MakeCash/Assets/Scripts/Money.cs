using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Money : MonoBehaviour
{
    private ObjectPool<Money> pool;
    [SerializeField] private float disableTime;
  //  [SerializeField] private float fallForce;
  //  private Rigidbody rb;

    private Coroutine DeactivateMoneyAfterTimeCoroutine;
    private void Awake()
    {
     //   rb= GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        DeactivateMoneyAfterTimeCoroutine = StartCoroutine(DeactivateMoneyAfterTime());
     //   TODO: dusme hizini ayarla

    }
    public void SetPool(ObjectPool<Money> pool)
    {
        this.pool=pool;
    }
    private IEnumerator DeactivateMoneyAfterTime()
    {
        var timeElapsed = 0f;
        while (timeElapsed < disableTime)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        pool.Release(this);
    }
}
