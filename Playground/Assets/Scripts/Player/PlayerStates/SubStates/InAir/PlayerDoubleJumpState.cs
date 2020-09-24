using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerInAirState
{
    private bool JumpInput;
    public PlayerDoubleJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
    }
     public override void DoChecks()
    {
        base.DoChecks();
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.jumpVelocity);
        player.RemainingJumps -= 1;
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.CurrentVelocity.y < 0.01f) {
            stateMachine.ChangeState(player.StartFallState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    } 
}
