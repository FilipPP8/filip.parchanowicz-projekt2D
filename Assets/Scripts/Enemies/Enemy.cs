using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

[SerializeField] HealthSystem _healthSystem;
[SerializeField] Bullet _bulletPrefab;
[SerializeField] Rigidbody2D _rigidBody2D;

[SerializeField] float _speed;

[SerializeField] float _minInterval, _maxInterval;

private float _timer = -1f;

private void Awake() 
{
    _healthSystem.OnHealthDepleted += _healthSystem_OnHealthDepleted;
}

private void Update() 
{
    if(_timer <= 0)
    {
        _timer = Random.Range(_minInterval, _maxInterval);
        Shoot();
    }

    _timer -= Time.deltaTime;    
}

private void Shoot()
{
        Bullet createdBullet = Instantiate<Bullet>(_bulletPrefab, 
        transform.position, Quaternion.identity);

        createdBullet.Shoot(Vector3.left);
}
private void FixedUpdate() 
{
    _rigidBody2D.velocity = Vector2.left * _speed;    
}
private void OnDestroy() 
{
    _healthSystem.OnHealthDepleted -= _healthSystem_OnHealthDepleted;
}

private void _healthSystem_OnHealthDepleted()
{
    Destroy(gameObject);
}

private void OnTriggerEnter2D(Collider2D collision) 
{

HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

 if(healthSystem != null)
 {
     healthSystem.TakeHit(1);
     _healthSystem.TakeHit(1);
 }

}

}
