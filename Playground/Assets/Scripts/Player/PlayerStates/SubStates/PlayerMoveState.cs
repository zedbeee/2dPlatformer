﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{

    private bool SprintInput;

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
        SprintInput = player.InputHandler.SprintInput;
        if (SprintInput) {
            player.SetVelocityX(playerData.sprintVelocity * xInput);
        }
        player.SetVelocityX(playerData.movementVelocity * xInput);
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

