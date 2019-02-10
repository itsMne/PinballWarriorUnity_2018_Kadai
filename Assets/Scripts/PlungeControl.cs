using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************
 ****PlungerControlクラス******
 *プランジャーをコントロールする*
 *****************************/

public class PlungeControl : MonoBehaviour {
    [SerializeField]
    private float fPullPower = 5.0f;//プランジャーを引く力
    [SerializeField]
    private KeyCode keycode = KeyCode.Space;//プランジャーをコントロールするキー
    [SerializeField]
    private string buttonName;//ゲームコントローラーのボタン
    private Vector3 v3PullPos;//最初の所
    Rigidbody rBody;
    float nCount;//力を使うカウンター
	// Use this for initialization
	void Start () {
        v3PullPos = transform.position + new Vector3(0, 0, -nCount);
        rBody = gameObject.GetComponent<Rigidbody>();
        nCount = 0;

    }
	
	// Update is called once per frame
	void Update () {
        //キーが押されている状態なら常にTrue
        if (Input.GetKey(keycode) || Input.GetButton(buttonName))
        {
            if (nCount < fPullPower)
            {
                v3PullPos = transform.position + new Vector3(0, 0, -nCount);
                rBody.isKinematic = true;
                rBody.MovePosition(v3PullPos);
                nCount += 0.05f;
            }
        }
        else
        {
            rBody.isKinematic = false;
            if (nCount > 0)
                nCount -= 0.25f;
        }
	}
}
