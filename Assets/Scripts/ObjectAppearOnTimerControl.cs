using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearOnTimerControl : MonoBehaviour {
    /*********************************
     **ObjectAppearOnTimerControl.cs**
     *タイマーによってオブジェクトを表す*
     *********************************/
    [SerializeField]
    private GameObject ObjectToAppear;//使うオブジェクト
    [SerializeField]
    float fTimer;//タイマーの限定
    float fCounter;//タイマーのカウンター
	// Use this for initialization
	void Start () {
        fCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (fCounter < fTimer)
            fCounter+=Time.deltaTime;
        else
        {
            fCounter = 0;
            if (ObjectToAppear.activeInHierarchy) {
                ObjectToAppear.SetActive(false);
            } else {
                ObjectToAppear.SetActive(true);
            }
        }
	}
}
