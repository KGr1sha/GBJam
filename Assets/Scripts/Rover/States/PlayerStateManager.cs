using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //States
    private PlayerBaseState currentState;
    public PlayerNormalState NormalState = new PlayerNormalState();
    public PlayerMiningState MiningState = new PlayerMiningState();

    //Other
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
