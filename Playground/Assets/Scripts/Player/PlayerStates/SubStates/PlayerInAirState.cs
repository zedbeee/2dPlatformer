using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool diveInput;
    private float xVelocity;
    private int airTimeFrames;
   public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
        ResetXVelocity();
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
    private void ResetXVelocity()
    {
        xVelocity = player.CurrentVelocity.x;
        airTimeFrames = 0;
    }
    private float GetXVelocity()
    {
        //Check if it's the first frame that you are in the air
        if(airTimeFrames == 0)
                if (player.InputHandler.SprintInput)
                    xVelocity += playerData.sprintVelocity;
        airTimeFrames++;
        return xInput * playerData.movementVelocity;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        diveInput = player.InputHandler.DiveInput;

        if (isGrounded && player.CurrentVelocity.y < 0.01f){
            stateMachine.ChangeState(player.LandState);
            ResetXVelocity();
        }
        else if (diveInput && !isGrounded){
            stateMachine.ChangeState(player.DiveState);
        }
        else if (jumpInput && player.JumpState.CanJump()){
            stateMachine.ChangeState(player.JumpState);
            player.CheckIfShouldFlip(xInput);
        }
       
        else {
            player.SetVelocityX(GetXVelocity());
            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(GetXVelocity()));

        }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}

