using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] GameObject _healthPowerupPrefab;
    void Start()
    {
        GameEvents.OnEnemyDied += GameEvents_OnEnemyDied;
    }
    private void GameEvents_OnEnemyDied(Enemy obj)
    {
        var randomFloat = Random.Range(1f, 100f);

        if (randomFloat <= 33f)
        {
            SpawnHealthPowerup(obj.transform.position);
        }
    }

    private void SpawnHealthPowerup(Vector3 position)
    {
        Instantiate(_healthPowerupPrefab, position, Quaternion.identity);
    }
}
