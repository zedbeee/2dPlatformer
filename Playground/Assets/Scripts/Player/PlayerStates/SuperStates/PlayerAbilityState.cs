using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    protected bool isGrounded;
    protected int xInput;
    protected int yInput; 
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
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
        isAbilityDone = false;
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        if (isAbilityDone){
            if (isGrounded && player.CurrentVelocity.y < 0.01f){
                if (yInput == -1){
                    stateMachine.ChangeState(player.CrouchState);
                }
                else {
                    stateMachine.ChangeState(player.IdleState);
                    }
            }
            else{
                stateMachine.ChangeState(player.StartFallState);
            }
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}

