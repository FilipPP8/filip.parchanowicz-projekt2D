using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDView : BaseView
{
 
    [SerializeField] TMP_Text _lifeCounter;
    [SerializeField] TMP_Text _scoreCounter;

    public override void ShowView()
    {
        base.ShowView();
        
        PlayerController.Instance.HealthSystem.OnHealthChanged +=
        HealthSystem_OnHealthChanged;

        GameEvents.OnScoreUpdated += GameEvents_OnScoreUpdated;
        UpdateText(PlayerController.Instance.HealthSystem.CurrentHp);
    }

    private void GameEvents_OnScoreUpdated(int score)
    {
        _scoreCounter.text = score.ToString();
    }
    private void HealthSystem_OnHealthChanged(int obj)
    {
        UpdateText(obj);
    }

    private void UpdateText(int hpCount)
    {
        //_lifeCounter.text = "Lives: " + hpCount.ToString();
        _lifeCounter.text = $"Lives: {hpCount}";
    }

    public override void HideView()
    {
        base.HideView();
    }

}
