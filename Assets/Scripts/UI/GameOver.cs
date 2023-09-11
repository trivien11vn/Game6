using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : Dialog
{
    public Text bestScoreText;
    public bool isReplay;
    public override void Show(bool isShow){
        base.Show(isShow);
        if(bestScoreText){
            bestScoreText.text = SaveBestScore.bestScore.ToString();
        }
    }
    private void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    public void Replay(){
        isReplay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Home(){
        GameGUIManager.Ins.ShowGameGUI(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode){
        if(isReplay){
            GameGUIManager.Ins.ShowGameGUI(true);
            GameManager.Ins.PlayGame();
        }
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
}
