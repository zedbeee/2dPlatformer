using System.Collections;
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
        
        //set ability done to true when animation ends
        if (!isAbilityDone && isAnimationFinished){
            
            isAbilityDone = true;
        }

    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        
    }
}
