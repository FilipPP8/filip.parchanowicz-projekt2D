using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : BaseState
{
    public override void EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        UIManager.Instance.ShowLoseScreen();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(Input.GetKeyDown(KeyCode.R))
        {
            _myStateMachine.EnterState(new GameState());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
