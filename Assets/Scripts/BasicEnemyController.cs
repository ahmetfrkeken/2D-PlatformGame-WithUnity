using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool
        groundDetected,
        wallDetected;



    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkigState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }
    //-Walking State--------------------------------------------------------

    private void EnterWalkigState()
    {

    }

    private void UpdateWalkigState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position);
    }

    private void ExitWalkigState()
    {

    }

    //-Knockback State--------------------------------------------------------
    private void EnterKnockbackState()
    {

    }

    private void UpdateKnockbackState()
    {

    }

    private void ExitKnockbackState()
    {

    }

    //-Dead State--------------------------------------------------------

    private void EnterDeadState()
    {

    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }
    //-Other Functions--------------------------------------------------------

    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Walking:
                ExitWalkigState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;

        }
        switch (state)
        {
            case State.Walking:
                EnterWalkigState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;

        }

        currentState = state;
    }
}
