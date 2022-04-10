using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShooter : MonoBehaviour
{
   [SerializeField] PlayerController _myPlayerController; 
   [SerializeField] InputManager _inputManager;
   [SerializeField] Transform[] _bulletPositions;
   [SerializeField] Bullet _bulletPrefab;

    bool _areWeaponsDisabled;
    private void Awake() 
    {
        _myPlayerController.OnPlayerDied += _myPlayerController_OnPlayerDied;
        _myPlayerController.OnPlayerRespawned += _myPlayerController_OnPlayerRespawned;
    }
    private void Update() {

        if(_areWeaponsDisabled)
        {
            return;
        }

        if(_inputManager.ShootInput)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        foreach(var transformPosition in _bulletPositions)
        {
            Bullet createdBullet = Instantiate<Bullet>(_bulletPrefab, 
            transformPosition.position, Quaternion.identity);

            createdBullet.Shoot(Vector3.right);
        }

    }

    private void OnDestroy() 
    {
        _myPlayerController.OnPlayerDied -= _myPlayerController_OnPlayerDied;
        _myPlayerController.OnPlayerRespawned -= _myPlayerController_OnPlayerRespawned;
    }

    private void _myPlayerController_OnPlayerDied()
    {
        _areWeaponsDisabled = true;
    }

    private void _myPlayerController_OnPlayerRespawned()
    {
        _areWeaponsDisabled = false;
    }
}
