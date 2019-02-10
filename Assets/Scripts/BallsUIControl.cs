using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallsUIControl : MonoBehaviour {
    /***********************
    ***BallsUIControl.cs****
    *ボールの数をコントロール*
    ************************/
    PinballVariablesControl pVariablesControl;//ボールの変数にある場所。
    Text uiText;//オブジェクトのUIコンポーネント。
    // Use this for initialization
    void Start () {
        pVariablesControl = GameObject.FindGameObjectWithTag("PinballMode").GetComponent<PinballVariablesControl>();
        uiText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        uiText.text = ": "+pVariablesControl.NHP + "/" + pVariablesControl.MaxHP;

    }
}
