using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSquatState : PlayerGroundedState
{
    public PlayerJumpSquatState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {

    }
     public override void Enter()
    {
        base.Enter();
        
    }
    public override void AnimationTrigger() { 
        base.AnimationTrigger();
    }
    public override void AnimationFinishTrigger(){
        base.AnimationFinishTrigger();

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (isAnimationFinished){
            stateMachine.ChangeState(player.JumpState);
        }
        
    }
 
}
