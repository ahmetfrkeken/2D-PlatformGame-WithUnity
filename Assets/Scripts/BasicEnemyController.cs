using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private enum State
    {
        Moving,
        Knockback,
        Dead
    }

    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        movementSpeed,
        maxHealt,
        knockbackDuration;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;

    [SerializeField]
    private LayerMask whatIsGround;


    [SerializeField]
    private Vector2 knockbackSpeed;

    private float 
        currentHealt,
        knockbackStartTime;

    private int 
        facingDirection,
        damageDirection;
    private Vector2 movement;

    private bool
        groundDetected,
        wallDetected;


    private GameObject robber;
    private Rigidbody2D robberrb;
    private Animator robberAnim;

    private void Start()
    {
        robber = transform.Find("Robber").gameObject;
        robberrb = robber.GetComponent<Rigidbody2D>();
        robberAnim = robber.GetComponent<Animator>();

        facingDirection = 1;
    }
    private void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                UpdateMovingState();
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

    private void EnterMovingState()
    {

    }

    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if (!groundDetected || wallDetected)
        {
            flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, robberrb.velocity.y);
            robberrb.velocity = movement;
        }
    }

    private void ExitMovingState()
    {

    }

    //-Knockback State--------------------------------------------------------
    private void EnterKnockbackState()
    {
        knockbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x * damageDirection, knockbackSpeed.y);
        robberrb.velocity = movement;
        robberAnim.SetBool("Knockback", true);
    }

    private void UpdateKnockbackState()
    {
        if(Time.time >= knockbackStartTime + knockbackDuration)
        {
            SwitchState(State.Moving);
        }
    }

    private void ExitKnockbackState()
    {
        robberAnim.SetBool("Knockback", false);
    }

    //-Dead State--------------------------------------------------------

    private void EnterDeadState()
    {
        //SpawnChunks And Blood
        Destroy(gameObject);
    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }
    //-Other Functions--------------------------------------------------------
    
    private void Damage(float[] attackDetails)
    {
        currentHealt -= attackDetails[0];

        if (attackDetails[1] > robber.transform.position.x)
        {
            damageDirection = -1;
        }
        else
        {
            damageDirection = 1;
        }

        //Hit Particle

        if(currentHealt > 0.0f)
        {
            SwitchState(State.Knockback);
        }
        else if ( currentHealt <= 0.0f)
        {
            SwitchState(State.Dead); 
        }
    }
    
    private void flip() 
    {
        facingDirection *= -1;
        robber.transform.Rotate(0f, 180f, 0f);
    }
    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Moving:
                ExitMovingState();
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
            case State.Moving:
                EnterMovingState();
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance,wallCheck.position.y));
    }
}
