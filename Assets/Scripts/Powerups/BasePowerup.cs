using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BasePowerup : MonoBehaviour
{
  public virtual void TriggerEffect(Collider2D collision)
  {

  }

  private void OnTriggerEnter2D(Collider2D collision) 
  {
      TriggerEffect(collision);
  }

  public void DestroyPowerup()
{
    Destroy(gameObject);
}
}
