using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

[SerializeField] protected HealthSystem _healthSystem;
[SerializeField] protected Bullet _bulletPrefab;

[SerializeField] protected GameObject _explosionAnimation;

public GameObject ExplosionAnimation
{get {return _explosionAnimation;}}

[SerializeField] protected Rigidbody2D _rigidBody2D;

[SerializeField] protected float _speed;

[SerializeField] protected float _minInterval, _maxInterval;

protected float _timer = -1f;

float _despawnPosition;
public void Initialize(float leftScreenEdgePosition)
{
    _despawnPosition = leftScreenEdgePosition;
}
protected virtual void Awake() 
{
    _healthSystem.OnHealthDepleted += _healthSystem_OnHealthDepleted;
    _timer = Random.Range(_minInterval, _maxInterval);
}

protected virtual void Update() 
{
    if(_timer <= 0)
    {
        _timer = Random.Range(_minInterval, _maxInterval);
        Shoot();
    }

    _timer -= Time.deltaTime;    
}

private void LateUpdate()
{
    if (transform.position.x < _despawnPosition)
    {
        DestroyEnemy();
    }
    

}

protected virtual void Move()
{
    _rigidBody2D.velocity = Vector2.left * _speed;    

}


protected virtual void Shoot()
{
        Bullet createdBullet = Instantiate<Bullet>(_bulletPrefab, 
        transform.position, Quaternion.identity);

        createdBullet.Shoot(Vector3.left);
        
    if (AudioManager.Instance !=null)    
    {
    AudioManager.Instance.PlaySound("EnemyShoot");
    }
}


private void FixedUpdate() 
{
    Move();
}
private void OnDestroy() 
{
    _healthSystem.OnHealthDepleted -= _healthSystem_OnHealthDepleted;
}

protected void _healthSystem_OnHealthDepleted()
{
    DestroyEnemy();
    GameEvents.EnemyDied(this);
}

public void DestroyEnemy()
{
    if(gameObject.tag == "StrongerEnemy")
    {
        EnemySpawner.Instance._isStrongerEnemyAlive = false;
        Destroy(gameObject);
    }
    else if (gameObject.tag == "Boss")
    {
        EnemySpawner.Instance._isBossAlive = false;
        Destroy(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }

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
