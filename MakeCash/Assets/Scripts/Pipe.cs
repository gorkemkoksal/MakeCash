using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Transform coin;
    [SerializeField] private Transform cash;
    private Player player;
  //  private Animator animator;
    private float speed; //animation speed gonna increase
    private float income;
    private void Awake()
    {
   //     animator = GetComponent<Animator>();
    }
    private void Start()
    {
        player = transform.GetComponentInParent<Player>();
      //  Player.onAnyTouch += Pipe_MakeMoney;
    }
    private void OnDestroy()
    {
     //   Player.onAnyTouch -= Pipe_MakeMoney;
    }
    private void Pipe_MakeMoney()
    {
        //TODO pipe animation plays

    }
}
