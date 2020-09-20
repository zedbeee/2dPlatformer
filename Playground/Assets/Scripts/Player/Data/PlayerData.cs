using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 5f;
    public int amountOfJumps = 2;

    [Header("Turn State")]
    public float turnVelocity = 5f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;

    [Header("Sprint State")]
    public float sprintVelocity = 15f;

    [Header("Dive State")]
    public float diveVelocity = -2f;

    public LayerMask whatIsGround;
}
