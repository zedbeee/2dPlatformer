﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool diveInput;
    protected bool startedFall;
    private int amountOfJumpsLeft;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }
    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfTouchingGround();
    }
    public override void Enter()
    {
        base.Enter();
        startedFall = false;

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

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            player.RemainingJumps = player.NumberOfJumps;
            stateMachine.ChangeState(player.LandState);
        }
        else if (diveInput && !isGrounded)
        {
            stateMachine.ChangeState(player.DiveState);
        }
        else if (jumpInput && CanJump())
        {
            stateMachine.ChangeState(player.DoubleJumpState);
        }
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public bool CanJump()
    {
        return player.RemainingJumps > 0;
    }
}