using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseView : BaseView
{

    [SerializeField] StateMachine _gameStateMachine;
    [SerializeField] TMP_Text _highscore;
    public override void ShowView()
    {
        base.ShowView();
        _highscore.text = "Highscore:\n" + PlayerPrefs.GetInt("Highscore").ToString();
 
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        _highscore.text = "Highscore:\n 0";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

public void OnMainMenuButtonPressed()
{
    _gameStateMachine.EnterState(new MenuState());
    HideView();
}



    
}
