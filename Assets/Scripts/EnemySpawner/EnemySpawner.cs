using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy _enemyPrefab;
 private void Start() 
 {
    var _activeCamera = Camera.main;

    Vector3 bottomLeftPosition = _activeCamera.ScreenToWorldPoint(Vector3.zero);
    Vector3 topRightPosition = _activeCamera.ScreenToWorldPoint (
        new Vector3(_activeCamera.pixelWidth, _activeCamera.pixelHeight));

    var bottomY = bottomLeftPosition.y;
    var topY = topRightPosition.y;

    var rightEdge = topRightPosition.x; //- bottomLeftPosition.x;

    for (int i = 0; i <5 ; i++)
    {
    Instantiate<Enemy>(_enemyPrefab, 
    new Vector3(rightEdge, Random.Range(bottomY, topY), 0), 
    Quaternion.identity);
    }
 }


}
