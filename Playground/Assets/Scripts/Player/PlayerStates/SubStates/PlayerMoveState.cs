using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {  
        base.LogicUpdate();
        float SprintOffset = player.InputHandler.SprintInput ? playerData.sprintVelocity : 0;
        player.SetVelocityX((playerData.movementVelocity + SprintOffset) * xInput);
        if (xInput == 0f){           
            stateMachine.ChangeState(player.IdleState);
        }
        if (xInput != player.CheckFacingDirection()){
            stateMachine.ChangeState(player.TurnState);
        }

    }
    public override void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }    
    
}

