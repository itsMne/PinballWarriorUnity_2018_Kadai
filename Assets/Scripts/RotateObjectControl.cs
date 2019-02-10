using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectControl : MonoBehaviour {
    /**************************
     *RotateObjectControl.cs***
     *****オブジェクトを回る*****
     **************************/
    [SerializeField]
    float speed;//回りの速さ
    //回りのアクシス
    [SerializeField]
    bool yAxis;
    [SerializeField]
    bool xAxis;
    [SerializeField]
    bool zAxis;
    [SerializeField]
    float directionTimer;//回りの向きを変更するタイマーの限定
    float checktimer;//回りの向きを変更するタイマー
    // Use this for initialization
    void Start () {
        checktimer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChangeDirectionsControl();
        RotationControl();
    }

    private void ChangeDirectionsControl()
    {
        if (directionTimer != 0)
        {
            checktimer += Time.deltaTime;
            if (checktimer >= directionTimer)
            {
                speed *= -1;
                checktimer = 0;
            }
        }
    }

    private void RotationControl()
    {
        if (yAxis)
            transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
        if (xAxis)
            transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
        if (zAxis)
            transform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}
