using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    float _spawnPosition, _approachPosition, _yMin, _yMax;
    float _approachSpeed = 2f;

    private float _rocketTimer = -1f;
    bool _movingUp = true;
    [SerializeField] Bullet _rocketPrefab;
   [SerializeField] Transform[] _bulletPositions;

   [SerializeField] Transform[] _rocketPositions;


   protected override void Awake() 
{
    _healthSystem.OnHealthDepleted += _healthSystem_OnHealthDepleted;
    _timer = Random.Range(_minInterval, _maxInterval);
    _rocketTimer = Random.Range(_minInterval*1.5f, _maxInterval*1.5f);
}
    void Start()
    {
    var _activeCamera = Camera.main;

    Vector3 bottomLeftPosition = _activeCamera.ScreenToWorldPoint(Vector3.zero);
    Vector3 topRightPosition = _activeCamera.ScreenToWorldPoint (
        new Vector3(_activeCamera.pixelWidth, _activeCamera.pixelHeight));

    _yMin = bottomLeftPosition.y;
    _yMax = topRightPosition.y;


    _spawnPosition = topRightPosition.x - (bottomLeftPosition.x/2);
    _approachPosition = topRightPosition.x;

    transform.position = new Vector3(_spawnPosition, 0, 0);
    }

    protected override void Update() 
{
    if(_timer <= 0)
    {
        _timer = Random.Range(_minInterval, _maxInterval);
        Shoot();
    }

    _timer -= Time.deltaTime; 

    if(_rocketTimer <= 0)
    {
        _rocketTimer = Random.Range(_minInterval*1.5f,_maxInterval*1.5f);
        ShootRockets();
    }
    _rocketTimer -= Time.deltaTime;
}
    protected override void Move()
    {

    _rigidBody2D.velocity = Vector2.left * _approachSpeed; 

    if (Mathf.Round(transform.position.x+2) == Mathf.Round(_approachPosition))
    {
        _approachSpeed = 0f;
        UpAndDownMove();
    }
     
    }

    private void UpAndDownMove()
    {
     if(_movingUp == true)
     {
         _rigidBody2D.velocity = Vector2.up * _speed;
     }
     else
     {
         _rigidBody2D.velocity = Vector2.down * _speed;
     }

     if(transform.position.y > _yMax)
     {
        _movingUp = false;
     }

     if (transform.position.y < _yMin)
     {
         _movingUp = true;
     }
    }
    protected override void Shoot()
    {
        foreach(var transformPosition in _bulletPositions)
        {
        Bullet createdBullet = Instantiate<Bullet>(_bulletPrefab, 
        transformPosition.position, Quaternion.identity);

        createdBullet.Shoot(Vector3.left);
        }
    if (AudioManager.Instance !=null)    
    {
    AudioManager.Instance.PlaySound("EnemyShoot");
    }
    }

    private void ShootRockets()
    {
        foreach(var transformPosition in _rocketPositions)
        {
        Bullet createdRocket = Instantiate<Bullet>(_rocketPrefab, 
        transformPosition.position, Quaternion.identity);

        createdRocket.Shoot(Vector3.left);
        }
    if (AudioManager.Instance !=null)    
    {
    AudioManager.Instance.PlaySound("EnemyShoot");
    }
    }


}
