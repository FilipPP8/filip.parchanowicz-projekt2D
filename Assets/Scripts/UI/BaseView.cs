using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    protected RectTransform _rectTransform;
    public virtual void ShowView()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        gameObject.SetActive(false);
    }

    public RectTransform GetRect()
    {
        if(_rectTransform == null)
        { 
            _rectTransform = GetComponent<RectTransform>();
        }

        return _rectTransform;
    }
}
