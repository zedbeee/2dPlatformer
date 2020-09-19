using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput{get; private set;}
    public int NormInputX {get; private set;}
    public int NormInputY {get; private set;}
    public bool JumpInput{get; private set;}
    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;

    private void Update() {
        CheckJumpInputHoldTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context){
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int)(RawMovementInput*Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput*Vector2.up).normalized.y;

    }
    public void onJumpInput(InputAction.CallbackContext context){
        if (context.started){
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }
        if (context.performed){
            //Jump being held
        }
        if (context.canceled){
            //Jump released
        }
    }

    public void UseJumpInput() => JumpInput = false;
    private void CheckJumpInputHoldTime(){
        if (Time.time >= jumpInputStartTime + inputHoldTime){
            JumpInput = false;
        }
    }
}
