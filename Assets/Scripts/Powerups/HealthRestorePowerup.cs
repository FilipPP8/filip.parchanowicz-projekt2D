using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestorePowerup : BasePowerup
{
    [SerializeField] Rigidbody2D _rigidBody2D;
    private float _speed = 2f;
    private float _lifeLenght = 10f;

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate() 
    {
        Destroy(gameObject, _lifeLenght);    
    }


    public override void TriggerEffect(Collider2D collision)
    {
        base.TriggerEffect(collision);

        var healthsystem = collision.GetComponent<HealthSystem>();

        if(healthsystem != null)
        {
            healthsystem.Heal(1);
            Destroy(gameObject);
        }
    }
   private void Move()
{
    _rigidBody2D.velocity = Vector2.left * _speed;    

} 

}
