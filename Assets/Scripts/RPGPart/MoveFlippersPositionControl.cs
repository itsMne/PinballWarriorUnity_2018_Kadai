using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlippersPositionControl: MonoBehaviour {

    /****************************************
     *****MoveFlippersPositionControl.cs*****
     *******フリッパを動くコントローラー********
     ********RPGモードでしか使えない***********
     ****************************************/
    /*[SerializeField]
    KeyCode MoveFlips;//フリッパに動かせるキー*/
    [SerializeField]
    GameObject leftFlip;//左フリッパ
    [SerializeField]
    GameObject rightFlip;//右フリッパ
    bool ogPos;//最初の所
    // Use this for initialization
    void Start () {
        ogPos = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Use"))
        {
            if (!ogPos)
            {
                leftFlip.transform.localPosition = new Vector3(0.51f, leftFlip.transform.localPosition.y, leftFlip.transform.localPosition.z);
                rightFlip.transform.localPosition = new Vector3(0.51f, rightFlip.transform.localPosition.y, rightFlip.transform.localPosition.z);
                ogPos = true;
            }
            else
            {
                leftFlip.transform.localPosition = new Vector3(0.19f, leftFlip.transform.localPosition.y, leftFlip.transform.localPosition.z);
                rightFlip.transform.localPosition = new Vector3(0.91f, rightFlip.transform.localPosition.y, rightFlip.transform.localPosition.z);
                ogPos = false;
            }
        }
    }
}
