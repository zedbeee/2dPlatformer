﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityOneState : PlayerAbilityState
{
    public Transform firepoint;
    public GameObject fireballPrefab;
    public PlayerAbilityOneState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter(){
        base.Enter();
        player.SetVelocityX(0f);
        player.InputHandler.UseAbilityOneInput();
        
          
    }
    public override void AnimationTrigger() { 
        base.AnimationTrigger();
        player.ShootFireball();
    }
    public override void AnimationFinishTrigger(){
        base.AnimationFinishTrigger();
        
    }
  
    public override void LogicUpdate(){
        base.LogicUpdate();
        
        if (!isAbilityDone && isAnimationFinished){
            if (player.InputHandler.AbilityOneInput){
            stateMachine.ChangeState(player.AbilityTwoState);
            }
            else {
                isAbilityDone = true;
            }
            
        }
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        
    }
}
