using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Achivement : Dialog
{
    public Text bestScoreText;
    public override void Show(bool isShow){
        base.Show(isShow);
        if(bestScoreText){
            bestScoreText.text = SaveBestScore.bestScore.ToString();
        }
    }
}
