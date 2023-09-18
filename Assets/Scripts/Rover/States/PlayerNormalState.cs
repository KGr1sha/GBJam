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
        
        //Rotate
        if (inputVector != Vector2.zero)
            player.transform.up = inputVector;

        //Switch to mining state
        if (Input.GetKeyDown(KeyCode.Space))
            player.SwitchState(player.MiningState);
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
}
