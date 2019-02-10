using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamerasControl : MonoBehaviour {
    /*****************************
　　  ****SwapCamerasControl.cs***
　　  *****カメラをスワップする*****
　　  ****************************/
    //カメラのオブジェクト
    [SerializeField]
    GameObject CameraA;
    [SerializeField]
    GameObject CameraB;
    //ゲームコントローラーのボタン
    [SerializeField]
    string buttonName;
    //カメラのコンポネント
    Camera CamAComponent;
    Camera CamBComponent;
    bool switched;//もうスワップしたことがあったら、Trueになる。
    private KeyCode keycode = KeyCode.S;//ゲームコントローラーのキー
    // Use this for initialization
    void Start () {
        switched = false;
        CamAComponent = CameraA.GetComponent<Camera>();
        CamBComponent = CameraB.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keycode) || Input.GetButtonDown(buttonName))
        {
            CameraSwitch();
        }

    }

    private void CameraSwitch()
    {
        if (!switched)
        {
            Rect cameraTemp = CamBComponent.rect;
            float tempDepth = CamBComponent.depth;
            CamBComponent.rect = CamAComponent.rect;
            CamAComponent.rect = cameraTemp;
            CamBComponent.depth = CamAComponent.depth;
            CamAComponent.depth = tempDepth;
            switched = true;
        }
        else
        {
            Rect cameraTemp = CamAComponent.rect;
            float tempDepth = CamAComponent.depth;
            CamAComponent.rect = CamBComponent.rect;
            CamBComponent.rect = cameraTemp;
            CamAComponent.depth = CamBComponent.depth;
            CamBComponent.depth = tempDepth;
            switched = false;
        }
    }
}
