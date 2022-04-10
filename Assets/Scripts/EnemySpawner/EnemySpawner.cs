using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] Enemy _enemyPrefab;

    private float _leftXPosition, _xPosition, _yMin, _yMax;
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

    // for (int i = 0; i <5 ; i++)
    // {
    //     SpawnEnemy();
    // }

 }

public void SpawnEnemy()
    {
    var enemy = Instantiate<Enemy>(_enemyPrefab, 
    new Vector3(_xPosition +2, Random.Range(_yMin, _yMax), 0), 
    Quaternion.identity);

    enemy.Initialize(_leftXPosition);
    }

 }



