using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerInAirState
{
    private bool JumpInput;
    private int jumpCount;
    
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.jumpVelocity);
        player.RemainingJumps-=1;
        player.InputHandler.UseJumpInput();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();
        JumpInput = player.InputHandler.JumpInput;
        
        if (player.CurrentVelocity.y < 0.01f) {
            stateMachine.ChangeState(player.StartFallState);
        }
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
                
    }  
}
