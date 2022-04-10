using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public event System.Action OnPlayerDied;
    public event System.Action OnPlayerRespawned;

    public HealthSystem HealthSystem
    {
        get {return _healthSystem;}
    }
    [SerializeField] InputManager _inputManager;
    [SerializeField] Rigidbody2D _rigidBody;
    [SerializeField] HealthSystem _healthSystem;
    [SerializeField] float _speed;

    [SerializeField] GameObject _playerSprite;

    [SerializeField] Collider2D[] _shipColliders;

    Camera _activeCamera;
    Rect _cameraBounds;

    Vector3 _spawnPosition;

    bool _isPlayerDead = true;
    public void Respawn()
    {
        transform.position = _spawnPosition;
        _healthSystem.ResetHP();
        _playerSprite.SetActive(true);
        _isPlayerDead = false;

        SwitchPlayerCollider(true);
        
        OnPlayerRespawned?.Invoke();
    }

    private void SwitchPlayerCollider(bool state)
    {
        foreach (var collider in _shipColliders)
        {
            collider.enabled = state;
        }
    }
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _spawnPosition = transform.position;

    }
    private void Start() 
    {
        _activeCamera = Camera.main;

        Vector3 bottomLeftPosition = _activeCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRightPosition = _activeCamera.ScreenToWorldPoint (
            new Vector3(_activeCamera.pixelWidth, _activeCamera.pixelHeight));

        _cameraBounds = new Rect(bottomLeftPosition.x, bottomLeftPosition.y, 
        topRightPosition.x - bottomLeftPosition.x, 
        topRightPosition.y - bottomLeftPosition.y);  

        _healthSystem.OnHealthDepleted += _healthSystem_OnHealthDepleted;
    }


    private void OnDestroy()
    {
        _healthSystem.OnHealthDepleted -= _healthSystem_OnHealthDepleted;
    }

    private void _healthSystem_OnHealthDepleted()
    {
        OnPlayerDied?.Invoke();
        DisablePlayer();
    }

    private void DisablePlayer()
    {
        _playerSprite.SetActive(false);
        _isPlayerDead = true;

        SwitchPlayerCollider(false);
    }

    private void FixedUpdate() 
    {
        if(_isPlayerDead)
        {
            return;
        }
        Vector2 _movementVector = new Vector2 
        (_inputManager.HorizontalInput * _speed, _inputManager.VerticalInput * _speed);

        _rigidBody.AddForce(_movementVector);
    }

    private void LateUpdate() 
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _cameraBounds.xMin, _cameraBounds.xMax),
            Mathf.Clamp(transform.position.y, _cameraBounds.yMin, _cameraBounds.yMax),
            transform.position.z
        );    


    }

}
