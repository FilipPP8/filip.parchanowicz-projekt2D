using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDView : BaseView
{
 
    [SerializeField] TMP_Text _lifeCounter;
    [SerializeField] TMP_Text _scoreCounter;

    [SerializeField] GameObject _pauseText;

    public override void ShowView()
    {
        base.ShowView();

        _pauseText.SetActive(false);
        
        PlayerController.Instance.HealthSystem.OnHealthChanged +=
        HealthSystem_OnHealthChanged;

        GameEvents.OnScoreUpdated += GameEvents_OnScoreUpdated;
        UpdateText(PlayerController.Instance.HealthSystem.CurrentHp);

        GameEvents.OnGamePaused += GameEvents_OnGamePaused;
    }

    private void GameEvents_OnGamePaused(bool pauseState)
    {
        _pauseText.SetActive(pauseState);
    }
    private void GameEvents_OnScoreUpdated(int score)
    {
        _scoreCounter.text = "Score: " + score.ToString();

    }
    private void HealthSystem_OnHealthChanged(int obj)
    {
        UpdateText(obj);
    }

    private void UpdateText(int hpCount)
    {
        _lifeCounter.text = $"Lives: {hpCount}";
    }

    public override void HideView()
    {
        base.HideView();
        GameEvents.OnGamePaused -= GameEvents_OnGamePaused;

    }

}
