using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
   [SerializeField] SpriteRenderer _sprite;
   [SerializeField] Color _colorStart, _colorEnd;

    private void OnTriggerEnter2D(Collider2D other) 
   {
      if(other.tag != "Powerup") 
      {
        StartCoroutine(ColorChangeOnHit());
      }
   }

   IEnumerator ColorChangeOnHit()
   {
    float progress = 0f;
    bool riseUp = true;

    while(true)
    { 
        _sprite.color = Color.Lerp(_colorStart, _colorEnd, progress);

        if (riseUp == true)
       {
            progress += Time.unscaledDeltaTime;
       }
       else
       {
            progress -= Time.unscaledDeltaTime;
       }

        if(riseUp && progress >= 0.5f)
        {
            riseUp = false;
        }
        
        if(riseUp == false && progress <= 0f)
        {
            riseUp = true;
            break;
        }

        yield return null;
    }
    
 
        
   }
}
