using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    private Vector2 inputVector;

    public override void EnterState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        GetInput();
        CheckForCrystal();
    }

    public override void FixedUpdateState(PlayerStateManager player, Rigidbody2D rb)
    {
        rb.MovePosition(rb.position + inputVector * Time.fixedDeltaTime * player.MoveSpeed);
    }

    private void GetInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        inputVector = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void CheckForCrystal()
    {

    }
}
