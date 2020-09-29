using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityJumpOneState : PlayerAbilityState
{
    
    public PlayerAbilityJumpOneState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter(){
        base.Enter();
        player.SetVelocityX(0f);
        
          
    }
    public override void AnimationTrigger() { 
        base.AnimationTrigger();
        player.ShootFireBallJump();
    }
    public override void AnimationFinishTrigger(){
        base.AnimationFinishTrigger();
        
    }
  
    public override void LogicUpdate(){
        base.LogicUpdate();
        
        //set ability done to true when animation ends
        if (!isAbilityDone && isAnimationFinished){
            
            isAbilityDone = true;
        }
        else {
            player.SetVelocityX((playerData.movementVelocity * xInput)/2);
            player.SetVelocityY(0);
        }

    }
}
