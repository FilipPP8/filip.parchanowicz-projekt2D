using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
   TMP_Text _text;
   [SerializeField] Color _colorStart, _colorEnd;

   private void Awake() 
   {
       _text = GetComponent<TMP_Text>();
   }

   private void OnEnable() {
       StartCoroutine(ColorText());
   }

   IEnumerator ColorText()
   {
       float progress = 0f;
       bool riseUp = true;

       while(true)
       {
           _text.color = Color.Lerp(_colorStart, _colorEnd, progress);

           if (riseUp)
           {
               progress += Time.unscaledDeltaTime;
           }
           else
           {
               progress -= Time.unscaledDeltaTime;
           }

           if(riseUp && progress >= 1f)
           {
               riseUp = false;
           }
           
           if(!riseUp && progress <=0f)
           {
               riseUp = true;
           }

           yield return null;
       }
   }
}
