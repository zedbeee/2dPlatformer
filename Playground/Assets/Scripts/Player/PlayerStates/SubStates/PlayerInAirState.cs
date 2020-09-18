﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;
   public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {

    }
       public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfTouchingGround();
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
        
        xInput = player.InputHandler.NormInputX;

        if (isGrounded && player.CurrentVelocity.y < 0.01f){
            stateMachine.ChangeState(player.IdleState);
        }
        else {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);
            
            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));

        }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}

