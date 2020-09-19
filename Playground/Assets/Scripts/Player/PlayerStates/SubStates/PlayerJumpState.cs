using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private bool JumpInput;
    private int amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }
    public override void Enter()
    {
        base.Enter();
        //player.SetVelocityY(playerData.jumpVelocity);
        //isAbilityDone = true;
        amountOfJumpsLeft--;
    }

    public override void LogicUpdate(){
        base.LogicUpdate();
        //check to see if jump is being held
        JumpInput = player.InputHandler.JumpInput;
        //Set ability done when jump is no longer held
        if (!JumpInput) {
            isAbilityDone = true;
        }

    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        if (JumpInput) {
           player.SetVelocityY(playerData.jumpVelocity);
        } 
        
    }

    public bool CanJump(){
        if (amountOfJumpsLeft > 0){
            return true;
        } else {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;
    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
