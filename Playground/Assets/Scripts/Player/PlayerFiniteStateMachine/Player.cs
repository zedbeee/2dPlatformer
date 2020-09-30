using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine{get; private set;}
    public PlayerIdleState IdleState{get; private set;}
    public PlayerMoveState MoveState{get; private set;}
    public PlayerTurnState TurnState{get; private set;}
    public PlayerCrouchState CrouchState{get; private set;}
    public PlayerJumpState JumpState{get; private set;}
    public PlayerInAirState InAirState{get; private set;}
    public PlayerLandState LandState{get; private set;}
    public PlayerDiveState DiveState{get; private set;}
    public PlayerDoubleJumpState DoubleJumpState {get; private set;}
    public PlayerEndFallState EndFallState {get; private set;}
    public PlayerStartFallState StartFallState {get; private set;}
    public PlayerJumpSquatState JumpSquatState {get; private set;}
    public PlayerAbilityOneState AbilityOneState {get; private set;}
    public PlayerAbilityCrouchOneState AbilityCrouchOneState {get; private set;}
    public PlayerAbilityJumpOneState AbilityJumpOneState {get; private set;}
    public PlayerDodgeState DodgeState{get; private set;}

    [SerializeField]
    private PlayerData playerData;

    #endregion
    
    #region Components
   public Animator Anim {get; private set;}
   public PlayerInputHandler InputHandler {get; private set;}
   public Rigidbody2D RB{get; private set;}
   [SerializeField]
   public Transform firePointTall;
    [SerializeField]
   public Transform firePointShort;
[SerializeField]
   public Transform firePointJump;
   [SerializeField]
   public Transform firePointDive;
   [SerializeField]
   public GameObject fireBallPrefab; 
   [SerializeField]
   public GameObject[] fireDivePrefab; 
   #endregion

    #region Other Variables
   private Vector2 workspace;
   public Vector2 CurrentVelocity {get; private set;}
   public int FacingDirection {get; private set;}
   public bool isTurning {get; private set;}
   public bool isCrouching {get; private set;}
    public int RemainingJumps { get; set; }
    public int NumberOfJumps  { get; private set;}
   #endregion
    
    #region Check Transforms
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
    #endregion
  
    

   private void Awake() {
       //Awake handles one time instatiation of the state machine and state components
       //Super States do not need to be instatiated 
       StateMachine = new PlayerStateMachine();

       IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle" );
       MoveState = new PlayerMoveState(this, StateMachine, playerData, "move" );
       TurnState = new PlayerTurnState(this, StateMachine, playerData, "turn");
       JumpSquatState = new PlayerJumpSquatState(this,StateMachine, playerData, "jumpSquat");
       JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
       InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
       LandState = new PlayerLandState(this, StateMachine, playerData, "land");
       DiveState = new PlayerDiveState(this, StateMachine, playerData, "dive");
       DoubleJumpState = new PlayerDoubleJumpState(this, StateMachine, playerData, "doubleJump");
       EndFallState = new PlayerEndFallState(this, StateMachine, playerData, "endFall");
       StartFallState = new PlayerStartFallState(this, StateMachine, playerData, "startFall");
       AbilityOneState = new PlayerAbilityOneState(this, StateMachine, playerData, "abilityOne");
       CrouchState = new PlayerCrouchState(this, StateMachine, playerData, "crouch");
       AbilityCrouchOneState = new PlayerAbilityCrouchOneState(this, StateMachine, playerData, "abilityCrouchOne");
       AbilityJumpOneState = new PlayerAbilityJumpOneState(this, StateMachine, playerData, "abilityJumpOne");
       DodgeState = new PlayerDodgeState(this, StateMachine, playerData, "dodge");


   }

   private void Start() {
       Anim = GetComponent<Animator>();
       InputHandler = GetComponent<PlayerInputHandler>();
       RB = GetComponent<Rigidbody2D>();
       FacingDirection = 1;
       RemainingJumps = 2;
       NumberOfJumps = 2;
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
    #region SpellMethods

    public void ShootFireball(){
        Instantiate(fireBallPrefab, firePointTall.position, firePointTall.rotation);
    }
    public void ShootFireballLow(){
        Instantiate(fireBallPrefab, firePointShort.position, firePointShort.rotation);
    }
    public void ShootFireBallJump(){
        Instantiate(fireBallPrefab, firePointJump.position, firePointJump.rotation);
    }
    public void DiveKickAesthetics(){
        foreach (GameObject i in fireDivePrefab){
            Instantiate(i, firePointDive.position, firePointDive.rotation);
        }
    }
    #endregion

    public void SetTurning(bool a){
        isTurning = a;
    }
    public bool CheckIfCrouching(){
        return isCrouching;
    }
    public void SetCrouching(bool a){
        isCrouching = a;
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

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void Flip(){
       FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
   }
   public bool CheckIfTouchingGround(){
       return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
   }
   public bool CheckIfTouchingWall(){
       return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
   }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "moving_platform")
            transform.SetParent(collision.gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "moving_platform")
            transform.SetParent(null);
    }
}
