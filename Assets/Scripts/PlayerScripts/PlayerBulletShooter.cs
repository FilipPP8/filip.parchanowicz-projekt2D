using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShooter : MonoBehaviour
{
   [SerializeField] InputManager _inputManager;
   [SerializeField] Transform[] _bulletPositions;
   [SerializeField] Bullet _bulletPrefab;

    private void Update() {
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
}
