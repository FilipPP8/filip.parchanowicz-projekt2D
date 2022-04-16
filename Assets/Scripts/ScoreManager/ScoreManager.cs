using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score;
    private void Awake()
    {
        GameEvents.OnEnemyDied += GameEvents_OnEnemyDied;
    }

    private void GameEvents_OnEnemyDied(Enemy obj)
    {
        _score += 100;
        GameEvents.ScoreUpdated(_score);
        
        if (_score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", _score);
        }
    }

    private void OnDestroy() 
    {
        GameEvents.OnEnemyDied -= GameEvents_OnEnemyDied;
    }

    public void CheckHighscore()
    {
        if (_score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", _score);
        }
    }
    public void ResetScore()
    {
        _score = 0;
        GameEvents.ScoreUpdated(_score);
    } 

}
