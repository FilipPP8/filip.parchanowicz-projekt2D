using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    protected StateMachine _myStateMachine;

    public virtual void EnterState(StateMachine stateMachine)
    {
        _myStateMachine = stateMachine;
    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}

