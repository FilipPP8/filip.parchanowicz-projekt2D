using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

public static event System.Action<Enemy> OnEnemyDied;

public static event System.Action<bool> OnGamePaused;

public static void GamePaused(GameState gameState, bool pauseState)
{
    if (gameState == null)
    {
        return;
    }

    OnGamePaused?.Invoke(pauseState);
}

public static void EnemyDied(Enemy enemy)
{
    if(enemy == null)
    {
        return;
    }
    if (enemy.tag == "StrongerEnemy")
    {
        EnemySpawner.Instance._isStrongerEnemyAlive = false;
    }
    if (enemy.tag == "Boss")
    {
        EnemySpawner.Instance._isBossAlive = false;
    }
    
    GameObject createdExplosion = Instantiate<GameObject>(enemy.ExplosionAnimation,
    enemy.transform.position, Quaternion.identity);

    Destroy(createdExplosion, 3);

    OnEnemyDied?.Invoke(enemy);
}

public static event System.Action<int> OnScoreUpdated;

public static void ScoreUpdated(int score)
{
    OnScoreUpdated?.Invoke(score);
}

}
