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
    [SerializeField] private BoxCollider2D drillCollider;
    [SerializeField] private LayerMask mineralMask;
    private Rigidbody2D rb;
    public float MoveSpeed = 0.8f;

    public void SwitchState(PlayerBaseState newState)
    {
        newState.EnterState(this);
        currentState = newState;
    }

    public GameObject GetMineral()
    {
        var hit = Physics2D.BoxCast(drillCollider.bounds.center, drillCollider.bounds.size, transform.eulerAngles.z, transform.forward, 0f, mineralMask);
        if (hit.transform.CompareTag("Mineral")) // to-do: check with interface
            return hit.transform.gameObject;
        return null;
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
