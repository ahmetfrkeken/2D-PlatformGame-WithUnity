using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("JumpState")]
    public float jumpVelocity = 15f;
    public int amiountOfJumps = 1;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;


    [Header("Check Variables")]
    public float groundCheckRadius = 1f;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsGround;
}