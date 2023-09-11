using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutOfLimit : MonoBehaviour
{
    // Khi platform khong con trigger voi limit nua thi moi xoa
    private void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag(TagConsts.PLATFORM)){
            Destroy(col.gameObject);
        }
    }
}
