using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MoneySpawner : MonoBehaviour
{
    public ObjectPool<Money> _pool;
    [SerializeField] private Money moneyPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        _pool = new ObjectPool<Money>(OnCreateMoney, OnGetMoneyFromPool, OnReturnMoneyToPool, OnDestroyMoney, true, 30, 50);
    }
    private Money OnCreateMoney()
    {
        Money money = Instantiate(moneyPrefab, spawnPoint.position, Quaternion.identity);
        money.SetPool(_pool);
        return money;
    }
    private void OnGetMoneyFromPool(Money money)
    {
        money.transform.position = spawnPoint.position;
        money.gameObject.SetActive(true);
    }
    private void OnReturnMoneyToPool(Money money)
    {
        money.gameObject.SetActive(false);
    }
    private void OnDestroyMoney(Money money)
    {
        Destroy(money.gameObject);
    }
}
