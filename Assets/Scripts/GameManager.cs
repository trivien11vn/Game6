using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player playerPrefab;
    public Platform platformPrefab;
    public float minSpawnX;
    public float maxSpawnX;
    public float minSpawnY;
    public float maxSpawnY;
    public CamController mainCam;
    public float powerBarUp;
    Player m_player;
    int m_score;
    bool isGameStarted;

    public bool IsGameStarted { get => isGameStarted;}

    public override void Awake(){
        MakeSingleton(false);
    }
    public override void Start(){
        base.Start();
        GameGUIManager.Ins.UpdateScoreCounting(m_score);
        GameGUIManager.Ins.UpdatePowerBar(0,1);
        AudioController.Ins.PlayBackgroundMusic();
    }
    public void PlayGame(){
        StartCoroutine(PlatformInit());
        GameGUIManager.Ins.ShowGameGUI(true);
    }

    IEnumerator PlatformInit(){
        Platform platformCLone = null;
        if(platformPrefab){
            platformCLone = Instantiate(platformPrefab, new Vector2(0,UnityEngine.Random.Range(minSpawnY,maxSpawnY)),Quaternion.identity);
            platformCLone.id = platformCLone.gameObject.GetInstanceID();
        }
        yield return new WaitForSeconds(0.5f);
        if(playerPrefab){
            m_player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            m_player.lastPlatformId = platformCLone.id;
        }
        if(platformPrefab){
            float spawnX = m_player.transform.position.x + minSpawnX;
            float spawnY = UnityEngine.Random.Range(minSpawnY,maxSpawnY);
            Platform platformClonenew = Instantiate(platformPrefab,new Vector2(spawnX, spawnY),Quaternion.identity);
            platformClonenew.id = platformClonenew.gameObject.GetInstanceID();

        }
        yield return new WaitForSeconds(0.5f);
        isGameStarted = true;
    }
    public void CreatePlatform(){
        if(!platformPrefab||!playerPrefab) return;
        float spawnX = UnityEngine.Random.Range(m_player.transform.position.x + minSpawnX, m_player.transform.position.x + maxSpawnX);
        float spawnY = UnityEngine.Random.Range(minSpawnY,maxSpawnY);
        Platform platformClone = Instantiate(platformPrefab,new Vector2(spawnX, spawnY),Quaternion.identity);
        platformClone.id = platformClone.gameObject.GetInstanceID();
    }
    public void CreatePlatformAndLerp(float posX){
        if(mainCam){
            mainCam.LerpTrigger(posX + minSpawnX);
        }
        CreatePlatform();
    }
    public void AddScore(){
        m_score++;
        SaveBestScore.bestScore = m_score;
        GameGUIManager.Ins.UpdateScoreCounting(m_score);
        AudioController.Ins.PlaySound(AudioController.Ins.getScore);
    }


}
