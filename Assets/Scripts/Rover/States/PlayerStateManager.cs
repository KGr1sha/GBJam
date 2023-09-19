using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //States
    private PlayerBaseState currentState;
    public PlayerNormalState NormalState = new ();
    public PlayerMiningState MiningState = new ();

    //Other
    public Animator Animator { get; private set; }
    public BoxCollider2D DrillCollider;
    public LayerMask MineralMask;
    private Rigidbody2D rb;
    public float MoveSpeed = 0.8f;

    public void SwitchState(PlayerBaseState newState)
    {
        newState.EnterState(this);
        currentState = newState;
    }

    private void Start()
    {
        currentState = NormalState;
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this, rb);
    }
}
