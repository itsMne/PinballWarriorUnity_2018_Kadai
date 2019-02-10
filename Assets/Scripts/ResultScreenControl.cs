using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenControl : MonoBehaviour {
    /*******************************
     ****ResultScreenControl.cs****
     **結果の表面をコントロールする***
     *******************************/
    // Use this for initialization
    void Start () {
        int resultScore;
        resultScore = ScoreUITextControl.GetPoint();
        GetComponent<Text>().text = "貴方の得点は：　" + resultScore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
