using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    private bool JumpInput;
    private bool AbilityOneInput;
    private bool isGrounded;
    private bool isSquat;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
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
    //    player.JumpState.ResetAmountOfJumpsLeft();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;
        AbilityOneInput = player.InputHandler.AbilityOneInput;

        if (JumpInput && stateMachine.CurrentState != player.JumpSquatState){
            stateMachine.ChangeState(player.JumpSquatState);
        } else if (AbilityOneInput){
            stateMachine.ChangeState(player.AbilityOneState);
        } else if (!isGrounded){
            stateMachine.ChangeState(player.StartFallState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}
