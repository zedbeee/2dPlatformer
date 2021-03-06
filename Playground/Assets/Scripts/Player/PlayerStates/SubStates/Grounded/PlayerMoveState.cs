﻿using System.Collections;
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
        player.CheckIfShouldFlip(xInput);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {  
        base.LogicUpdate();
        
        
        if (!isExitingState) {
            float SprintOffset = player.InputHandler.SprintInput ? playerData.sprintVelocity : 0;
            player.SetVelocityX((playerData.movementVelocity + SprintOffset) * xInput);
            if (xInput == 0f){           
            stateMachine.ChangeState(player.IdleState);
            }
            else if (xInput != player.CheckFacingDirection()){
            stateMachine.ChangeState(player.TurnState);
            } 
            else if (yInput == -1){
            stateMachine.ChangeState(player.CrouchState);
            }
        }
    }
    public override void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }    
    
}

