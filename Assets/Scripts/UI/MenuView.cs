using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : BaseView
{
   [SerializeField] StateMachine _gameStateMachine;

    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void OnStartGameButtonPressed()
{
    _gameStateMachine.EnterState(new GameState());
    HideView();
}

}
