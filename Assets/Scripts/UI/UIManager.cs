using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] BaseView _loseView, _hudView, _menuView;

    public static UIManager Instance;

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
    }
    public void ShowMainMenu()
    {
        _menuView.ShowView();
        _hudView.HideView();
        _loseView.HideView();
    }   

    public void ShowHUD()
    {
        _hudView.ShowView();
        _menuView.HideView();
        _loseView.HideView();
    } 

    public void ShowLoseScreen()
    {
        _loseView.ShowView();
        _menuView.HideView();
        _hudView.HideView();
    }
}
