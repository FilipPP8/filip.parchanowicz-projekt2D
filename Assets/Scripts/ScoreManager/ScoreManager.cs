using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score;

    private int _basicEnemyScoreValue = 100;
    private int _strongerEnemyScoreValue = 200;

    public int Score {get{ return _score;} }
    private void Awake()
    {
        GameEvents.OnEnemyDied += GameEvents_OnEnemyDied;
    }

    private void GameEvents_OnEnemyDied(Enemy obj)
    {
        if (obj.tag == "StrongerEnemy")
        {
        _score += _strongerEnemyScoreValue;
        }
        else
        {
        _score += _basicEnemyScoreValue;
        }
        
        GameEvents.ScoreUpdated(_score);

        CheckHighscore();
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
