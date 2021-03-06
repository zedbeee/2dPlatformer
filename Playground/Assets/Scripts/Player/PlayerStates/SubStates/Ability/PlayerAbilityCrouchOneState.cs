﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityCrouchOneState : PlayerAbilityState
{

    public PlayerAbilityCrouchOneState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter(){
        base.Enter();
        player.SetVelocityX(0f);
        player.InputHandler.UseAbilityOneInput();
        
          
    }
    public override void AnimationTrigger() { 
        base.AnimationTrigger();
        player.ShootFireballLow();
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

    }
}
