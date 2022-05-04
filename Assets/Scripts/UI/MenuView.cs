using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuView : BaseView
{
   [SerializeField] StateMachine _gameStateMachine;
   [SerializeField] GameObject _mainMenuButtons;
   [SerializeField] GameObject _controlsPanel;
   [SerializeField] GameObject _highscorePanel;
    [SerializeField] TMP_Text _highscore;
    public override void ShowView()
    {
        base.ShowView();
        _controlsPanel.SetActive(false);
        _highscorePanel.SetActive(false);
        _highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
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

    public void OnQuitGameButtonPressed()
    {
        Application.Quit();
    }

public void OnHowToPlayButtonPressed()
{
    _mainMenuButtons.SetActive(false);

    _controlsPanel.SetActive(true);
}

public void OnBackToMenuButtonPressed()
{
    _mainMenuButtons.SetActive(true);

    _controlsPanel.SetActive(false);
    _highscorePanel.SetActive(false);
}

public void OnHighscoreButtonPressed()
{
    _mainMenuButtons.SetActive(false);

    _highscorePanel.SetActive(true);
}

public void OnResetHighscoreButtonPressed()
    {
        PlayerPrefs.DeleteKey("Highscore");
        _highscore.text = "0";
    }

public void MuteToggle(bool muted)
{

    if(muted == false)
    {
        AudioListener.volume = 0;
    }
    else
    {
        AudioListener.volume = 1;
    }
}

}
