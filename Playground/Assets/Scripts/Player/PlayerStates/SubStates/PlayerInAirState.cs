﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool diveInput;
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
        jumpInput = player.InputHandler.JumpInput;
        diveInput = player.InputHandler.DiveInput;

        if (isGrounded && player.CurrentVelocity.y < 0.01f){
            stateMachine.ChangeState(player.LandState);
        }
        else if (diveInput && !isGrounded){
            stateMachine.ChangeState(player.DiveState);
        }
        else if (jumpInput && player.JumpState.CanJump()){
            stateMachine.ChangeState(player.JumpState);
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

