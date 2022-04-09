using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] InputManager _inputManager;

    [SerializeField] Rigidbody2D _rigidBody;
    [SerializeField] HealthSystem _healthSystem;
    [SerializeField] float _speed;

    Camera _activeCamera;
    Rect _cameraBounds;

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
        Destroy(gameObject);
    }
    private void FixedUpdate() 
    {
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
