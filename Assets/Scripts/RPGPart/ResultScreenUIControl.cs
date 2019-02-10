using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResultScreenUIControl : MonoBehaviour {
    /*******************************
     ****ResultScreenUIControl.cs***
     **喧嘩は終わり表面にスコアを表す**
     *******************************/
    [SerializeField]
    bool receivedEXP;//もらったEXPポイント
    [SerializeField]
    bool nextEXP;//次のレベルの必要なEXPポイント
    Text thisText;//テクストのコンポネント
    RPGFightControl fightControl;//喧嘩のコントローラー
    StatsControl playerStats;//プレイヤーのステータスのコントローラー
    // Use this for initialization
    void Start () {
        thisText = GetComponent<Text>();
        if(receivedEXP)
            fightControl = GameObject.FindGameObjectWithTag("PinballMode").GetComponent<RPGFightControl>();
        if(nextEXP)
            playerStats = GameObject.Find("StatsController").GetComponent<StatsControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (receivedEXP)
            thisText.text = "" + fightControl.ExpForTheFight;
        if (nextEXP)
            thisText.text = "" + (playerStats.NNextEXP - playerStats.NEXP);
    }
}
