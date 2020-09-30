using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiveState : PlayerAbilityState
{
    public PlayerDiveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {

    }
    public override void DoChecks()
    {
        base.DoChecks();
        
    }
    public override void Enter(){
        base.Enter();
        //player.DiveKickAesthetics();
       
    }
  
    public override void LogicUpdate(){
        base.LogicUpdate();
        if (isGrounded){
            isAbilityDone = true;
            stateMachine.ChangeState(player.LandState);
        } else {
            
        }
        player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
        player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));

    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        player.SetVelocityY(playerData.diveVelocity);
    }
}
