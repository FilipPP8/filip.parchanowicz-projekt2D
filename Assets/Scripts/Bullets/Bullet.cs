using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
[SerializeField] Rigidbody2D _rigidBody;
[SerializeField] float _speed;
[SerializeField] float _lifeLenght;

public void Shoot(Vector3 direction)
{
    _rigidBody.AddForce(direction * _speed, ForceMode2D.Impulse);
    Destroy(gameObject, _lifeLenght);
}


private void OnCollisionEnter2D(Collision2D collision) 
{
    HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

 if(healthSystem != null)
 {
     healthSystem.TakeHit(1);
 }

 Destroy(gameObject);    
}


}
