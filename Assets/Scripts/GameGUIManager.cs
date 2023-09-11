using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public Text scoreCountingText;
    public Image powerBarSlider;
    public Dialog achivement;
    public Dialog help;
    public Dialog gameover;

    public override void Awake(){
        MakeSingleton(false);
    }
    public void ShowGameGUI(bool isShow){
        if(gameGUI){
            gameGUI.SetActive(isShow);
        }
        if(homeGUI){
            homeGUI.SetActive(!isShow);
        }
    }
    public void UpdateScoreCounting(int score){
        if(scoreCountingText){
            scoreCountingText.text = score.ToString();
        }
    }
    public void UpdatePowerBar(float curVal, float totalVal){
        if(powerBarSlider){
            powerBarSlider.fillAmount = curVal/totalVal;
        }
    }
    public void ShowAchivement(){
        if(achivement){
            achivement.Show(true);
        }
    }
    public void ShowHelp(){
        if(help){
            help.Show(true);
        }
    }
    public void ShowGameOver(){
        if(gameover){
            gameover.Show(true);
        }
    }
}
