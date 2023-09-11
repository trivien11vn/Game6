using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private void Update(){
        if(GameManager.Ins.mainCam != null){
            transform.position = new Vector3(GameManager.Ins.mainCam.transform.position.x,
                                            GameManager.Ins.mainCam.transform.position.y,
                                            0f);
        }
    }
}
