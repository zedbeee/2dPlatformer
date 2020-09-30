using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerAbilityState
{
    private Vector2 lastAfterImagePosition;
        public PlayerDodgeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {

    }
    public override void DoChecks()
    {
        base.DoChecks();
        
    }
    public override void Enter(){
        base.Enter();
        
    }
    public override void AnimationFinishTrigger(){
        base.AnimationFinishTrigger();
        
    }
  
    public override void LogicUpdate(){
        base.LogicUpdate();
        CheckIfShouldPlaceAfterImage();
        //PlaceAfterImage();
        if (!isAbilityDone && isAnimationFinished){
            
            isAbilityDone = true;
        }

    }
    
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
       
    }

    private void PlaceAfterImage(){
        PlayerAfterImagePool.Instance.GetFromPool();
        lastAfterImagePosition = player.transform.position;
    }
    private void CheckIfShouldPlaceAfterImage(){
        if (Vector2.Distance(player.transform.position, lastAfterImagePosition) >= playerData.distBetweenAfterImages){
            PlaceAfterImage();
        }
    }
}
