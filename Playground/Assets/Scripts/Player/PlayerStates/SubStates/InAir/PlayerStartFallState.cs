using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartFallState : PlayerInAirState
{
    public PlayerStartFallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
    }
    public override void AnimationTrigger() { 
        base.AnimationTrigger();
    }
    public override void AnimationFinishTrigger(){
        base.AnimationFinishTrigger();
        startedFall = true;

    }
    public override void DoChecks()
    {
        base.DoChecks();
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
        if (startedFall) {
            stateMachine.ChangeState(player.EndFallState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    } 
  
}
