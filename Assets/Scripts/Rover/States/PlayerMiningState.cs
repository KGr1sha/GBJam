using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiningState : PlayerBaseState
{
    private GameObject mineral;

    public override void EnterState(PlayerStateManager player)
    {
        mineral = player.GetMineral();
        Debug.Log("Mining " + mineral.tag);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //Back to normal state
        if (Input.GetKeyUp(KeyCode.Space))
            player.SwitchState(player.NormalState);


    }

    public override void FixedUpdateState(PlayerStateManager player, Rigidbody2D rb)
    {
        
    }
}
