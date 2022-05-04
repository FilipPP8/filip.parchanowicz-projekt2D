using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    public override void EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        UIManager.Instance.ShowMainMenu();
        
        if (AudioManager.Instance != null)
        {
        AudioManager.Instance.PlaySound("MenuTheme");
        AudioManager.Instance.StopSound("GameLoop");
        }

    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
