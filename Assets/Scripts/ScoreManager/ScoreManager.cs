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
    }

    private void OnDestroy() 
    {
        GameEvents.OnEnemyDied -= GameEvents_OnEnemyDied;
    }

}
