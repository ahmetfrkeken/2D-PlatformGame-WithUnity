using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    protected float startTime; //Enemy nin state e giriş zamanını belirler.

    protected string animBoolName;

    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }


    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);//varlığın enter anında animasyonunun başlamasını sağlar.
        DoChecks();
    }

    public virtual void Exit()
    {

        entity.anim.SetBool(animBoolName, false);//varlığın enter anında animasyonunun sonlanmasını sağlar.
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();

    }

    public virtual void DoChecks()
    {

    }
} 
