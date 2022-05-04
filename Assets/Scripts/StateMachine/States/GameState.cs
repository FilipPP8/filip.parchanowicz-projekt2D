using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{
    public static GameState Instance;
    private float _spawnInterval = 1.5f;

    private float _bossSpawnInterval = 25f;
    private float _currentTime;

    private float _currentTimeForBossSpawn;
    private int _score;
    bool _gamePaused = false;


    public override void EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        _currentTime = _spawnInterval;
        _currentTimeForBossSpawn = _bossSpawnInterval;

        PlayerController.Instance.OnPlayerDied += PlayerInstance_OnPlayerDied;
        PlayerController.Instance.Respawn();

        ClearUpAfterLastGame();

        UIManager.Instance.ShowHUD();
        Time.timeScale = 1f;
        
        GameEvents.OnEnemyDied += GameEvents_OnEnemyDied;

        if (AudioManager.Instance != null)
        {
        AudioManager.Instance.PlaySound("GameLoop");
        AudioManager.Instance.StopSound("MenuTheme");
        }
    }

    public override void UpdateState()
    {
        
        base.UpdateState();
        _currentTime -= Time.deltaTime;
        _currentTimeForBossSpawn -= Time.deltaTime;

        _score = PlayerController.Instance.ScoreManager.Score;

        if(_currentTime < 0f)
        {
            EnemySpawner.Instance.SpawnEnemy();
            _currentTime = _spawnInterval;
        }

        if (_score > 0 && _score % 300 == 0)
        {
            EnemySpawner.Instance.SpawnStrongerEnemy();
        }

        if (_currentTimeForBossSpawn < 0f)
        {
            EnemySpawner.Instance.SpawnBoss();
        }


        CheckPauseButton();

    }

    public override void ExitState()
    {
        PlayerController.Instance.OnPlayerDied -= PlayerInstance_OnPlayerDied;
        Time.timeScale = 1f;

        base.ExitState();
    }


    private void PlayerInstance_OnPlayerDied()
    {
        _myStateMachine.EnterState(new LoseState());
    }

    private void GameEvents_OnEnemyDied(Enemy obj)
    {
        if(obj.tag == "Boss")
        {
        _currentTimeForBossSpawn = _bossSpawnInterval;
        }
    }


    private void ClearUpAfterLastGame()
    {
        EnemySpawner.Instance._isStrongerEnemyAlive = false;
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();
        BasePowerup[] powerups = GameObject.FindObjectsOfType<BasePowerup>();

        foreach(Enemy enemy in enemies)
        {
            enemy.DestroyEnemy();
        }

        foreach(Bullet bullet in bullets)
        {
            bullet.DestroyBullet();
        }

        foreach(BasePowerup powerup in powerups)
        {
            powerup.DestroyPowerup();
        }
    }

    private void CheckPauseButton()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (_gamePaused)
            {
                Time.timeScale = 1f;
            }
            else 
            {
                Time.timeScale = 0f;
            }

            _gamePaused = !_gamePaused;
        }

        GameEvents.GamePaused(this, _gamePaused);
    }
}
