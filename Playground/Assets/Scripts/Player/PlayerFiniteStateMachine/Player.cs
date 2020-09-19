using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
   public PlayerStateMachine StateMachine{get; private set;}

   public PlayerIdleState IdleState{get; private set;}
   public PlayerMoveState MoveState{get; private set;}
   public PlayerTurnState TurnState{get; private set;}
   public PlayerJumpState JumpState{get; private set;}
   public PlayerInAirState InAirState{get; private set;}
   public PlayerLandState LandState{get; private set;}

[SerializeField]
   private PlayerData playerData;

    #endregion
    
    #region Components
   public Animator Anim {get; private set;}
   public PlayerInputHandler InputHandler {get; private set;}
   public Rigidbody2D RB{get; private set;}
   #endregion

    #region Other Variables
   private Vector2 workspace;
   public Vector2 CurrentVelocity {get; private set;}
   public int FacingDirection {get; private set;}
   public bool isTurning {get; private set;}
   #endregion
    
    #region Check Transforms
    [SerializeField]
    private Transform groundCheck;
    #endregion
  


   private void Awake() {
       //Awake handles one time instatiation of the state machine and state components
       //Super States do not need to be instatiated 
       StateMachine = new PlayerStateMachine();

       IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle" );
       MoveState = new PlayerMoveState(this, StateMachine, playerData, "move" );
       TurnState = new PlayerTurnState(this, StateMachine, playerData, "turn");
       JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
       InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
       LandState = new PlayerLandState(this, StateMachine, playerData, "land");

   }

   private void Start() {
       Anim = GetComponent<Animator>();
       InputHandler = GetComponent<PlayerInputHandler>();
       RB = GetComponent<Rigidbody2D>();
       FacingDirection = 1;
       StateMachine.Initialize(IdleState);
   }

   private void Update() {
       CurrentVelocity = RB.velocity;
       StateMachine.CurrentState.LogicUpdate();
   }

   private void FixedUpdate() {
       StateMachine.CurrentState.PhysicsUpdate();
   }

   public void SetVelocityX(float velocity){
       workspace.Set(velocity, CurrentVelocity.y );
       RB.velocity = workspace;
       CurrentVelocity = workspace;
   }
   public void SetVelocityY(float velocity){
       workspace.Set(CurrentVelocity.x, velocity);
       RB.velocity = workspace;
       CurrentVelocity = workspace;
   }

    public bool CheckTurning(){
        return isTurning;
    }

    public void SetTurning(bool a){
        isTurning = a;
    }

    public int  CheckFacingDirection(){
        return FacingDirection;
    }
    public void CheckIfShouldFlip(int xInput){
        if (xInput != 0 && xInput != FacingDirection){
            Flip();
        }
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void Flip(){
       FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
   }
   public bool CheckIfTouchingGround(){
       return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
   }
}
