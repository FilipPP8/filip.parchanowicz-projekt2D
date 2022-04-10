using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{
    private float _spawnInterval = 1.5f;
    private float _currentTime;

    int _spawnedShips = 0;
    public override void EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        _currentTime = _spawnInterval;

        PlayerController.Instance.OnPlayerDied += PlayerInstance_OnPlayerDied;
        PlayerController.Instance.Respawn();

        ClearUpAfterLastGame();

        UIManager.Instance.ShowHUD();

    }

    public override void UpdateState()
    {
        base.UpdateState();
        _currentTime -= Time.deltaTime;

        if(_currentTime < 0f)
        {
            EnemySpawner.Instance.SpawnEnemy();
            _currentTime = _spawnInterval;

            _spawnedShips++;

        }
    }

    public override void ExitState()
    {
        PlayerController.Instance.OnPlayerDied -= PlayerInstance_OnPlayerDied;
        
        base.ExitState();
    }

    private void PlayerInstance_OnPlayerDied()
    {
        _myStateMachine.EnterState(new LoseState());
    }

    private void ClearUpAfterLastGame()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();

        foreach(Enemy enemy in enemies)
        {
            enemy.DestroyEnemy();
        }

        foreach(Bullet bullet in bullets)
        {
            bullet.DestroyBullet();
        }
    }
}
