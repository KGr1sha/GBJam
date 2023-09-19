using UnityEngine;

public class PlayerMiningState : PlayerBaseState
{
    private IMinable mineral;

    public override void EnterState(PlayerStateManager player)
    {
        mineral = GetMineral(player);
        mineral?.StartMining();
        player.Animator.SetBool("IsMining", true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //Back to normal state
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.SwitchState(player.NormalState);
            player.Animator.SetBool("IsMining", false);
            if (mineral != null)
                mineral.StopMining();
        }
    }

    private IMinable GetMineral(PlayerStateManager player)
    {
        var hit = Physics2D.BoxCast(
            player.DrillCollider.bounds.center,
            player.DrillCollider.bounds.size,
            player.transform.eulerAngles.z,
            player.transform.forward, 0f,
            player.MineralMask);

        if (hit)
        {
            IMinable minable = hit.transform.GetComponent<IMinable>();
            return minable;
        }
        return null;   
    }

    public override void FixedUpdateState(PlayerStateManager player, Rigidbody2D rb)
    {
        
    }
}
