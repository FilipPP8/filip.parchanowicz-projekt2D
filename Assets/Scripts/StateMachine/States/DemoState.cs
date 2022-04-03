using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoState : BaseState
{
    public override void EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        Debug.Log("Demo state entered");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Demo state Update state");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Demo State Exit");
    }
}
