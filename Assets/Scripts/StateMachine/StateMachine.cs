using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
     BaseState _currentState;

private void Start()
{
    EnterState(new MenuState());
}

private void Update()
{
    _currentState.UpdateState();
}

private void OnDestroy()
{
    _currentState.ExitState();
}
public void EnterState(BaseState stateToEnter)
{
    if (_currentState != null)
    {
        _currentState.ExitState();
    }
    _currentState = stateToEnter;

    _currentState.EnterState(this);
}


public void OnStartGameButtonPressed()
{
    EnterState(new GameState());
}


}
