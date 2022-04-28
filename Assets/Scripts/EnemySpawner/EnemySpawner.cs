using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] Enemy _enemyPrefab;

    [SerializeField] Enemy _strongerEnemyPrefab;

    [SerializeField] Boss _bossPrefab;

    private float _leftXPosition, _xPosition, _yMin, _yMax;

    public bool _isStrongerEnemyAlive = false;

    public bool _isBossAlive = false;
 private void Awake() 
 {
    if (Instance == null)
    {
        Instance = this;
    }
    else
    {
        Destroy(gameObject);
        return;
    }

    var _activeCamera = Camera.main;

    Vector3 bottomLeftPosition = _activeCamera.ScreenToWorldPoint(Vector3.zero);
    Vector3 topRightPosition = _activeCamera.ScreenToWorldPoint (
        new Vector3(_activeCamera.pixelWidth, _activeCamera.pixelHeight));

    _yMin = bottomLeftPosition.y;
    _yMax = topRightPosition.y;

    _leftXPosition = bottomLeftPosition.x;

    _xPosition = topRightPosition.x; //- bottomLeftPosition.x; -> spawn behind the edge

 }

public void SpawnEnemy()
    {
        if(_isBossAlive == false)
        {
        var enemy = Instantiate<Enemy>(_enemyPrefab, 
        new Vector3(_xPosition +1, Random.Range(_yMin, _yMax), 0), 
        Quaternion.identity);

        enemy.Initialize(_leftXPosition);
        }
    }
public void SpawnStrongerEnemy()
{
    if (_isStrongerEnemyAlive == false && _isBossAlive == false)
    {
    var enemy = Instantiate<Enemy>(_strongerEnemyPrefab, 
    new Vector3(_xPosition +1, Random.Range(_yMin, _yMax), 0), 
    Quaternion.identity);

    enemy.Initialize(_leftXPosition);
    _isStrongerEnemyAlive = true;
    }
}

public void SpawnBoss()
{
    if (_isBossAlive == false)
    {
    var boss = Instantiate<Enemy>(_bossPrefab, 
    new Vector3 (_xPosition, 0, 0), Quaternion.identity);
    
    boss.Initialize(_leftXPosition);
    _isBossAlive = true;
    }
}
 }



