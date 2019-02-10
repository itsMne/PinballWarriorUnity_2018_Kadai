
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitchAnimationControl : MonoBehaviour {
    /*********************************
     *ModelSwitchAnimationControl.cs**
     *タイマーによってオブジェクトを表す*
     *********************************/
     //表すコントロールのオブジェクト
    [SerializeField]
    GameObject gOBJ1;
    [SerializeField]
    GameObject gOBJ2;
    float timer;//タイマーの限定
    [SerializeField]
    float time;//タイマー
    // Use this for initialization
    void Start () {
        timer = 0;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > time)
        {
            timer = 0;
            if (gOBJ1.activeInHierarchy)
            {
                gOBJ2.SetActive(true);
                gOBJ1.SetActive(false);
            }
            else
            {
                gOBJ2.SetActive(false);
                gOBJ1.SetActive(true);
            }
        }

    }
}
