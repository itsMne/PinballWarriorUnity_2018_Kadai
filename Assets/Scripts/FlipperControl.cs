using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour {
    /*＊＊＊＊＊＊＊＊＊＊
     ＊＊＊Flipper.cs＊＊
     *フリッパーのクラス＊
     ＊＊＊＊＊＊＊＊＊＊*/

    [SerializeField]
    private KeyCode keyCode = KeyCode.Space;//フリッパーがコントロール出来るキー
    [SerializeField]
    private float openAngle;//フリッパは開く角度
    [SerializeField]
    private string buttonName;//ゲームコントローラーの名前
    [SerializeField]
    private float closeAngle;//フリッパは閉める角度
    private HingeJoint hj;//ジョイントのコンポネント
    //private Rigidbody rBody;
    void Start () {
        hj = gameObject.GetComponent<HingeJoint>();
        //rBody = gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(keyCode) || Input.GetButton(buttonName))
        {
            CloseFlipper();
        }
        else {
            OpenFlipper();
        }

    }
    //CloseFlipper関数
    //フリッパを閉める
    public void CloseFlipper()
    {
        //HingeJointのSpringを取得
        JointSpring spr = hj.spring;
        spr.targetPosition = closeAngle;
        hj.spring = spr;
    }
    //OpenFlipper関数
    //フリッパを開ける
    public void OpenFlipper()
    {
        //HingeJointのSpringを取得
        JointSpring spr = hj.spring;
        spr.targetPosition = openAngle;
        hj.spring = spr;
    }
}
