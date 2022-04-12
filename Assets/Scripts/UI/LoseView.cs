using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseView : BaseView
{

    [SerializeField] TMP_Text _highscore;
    public override void ShowView()
    {
        base.ShowView();
        _highscore.text = "Highscore:\n" + PlayerPrefs.GetInt("Highscore").ToString();

    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        _highscore.text = "Highscore:\n 0";
    }

    
}
