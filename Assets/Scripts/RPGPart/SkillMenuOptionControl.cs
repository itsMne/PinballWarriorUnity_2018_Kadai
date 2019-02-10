using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenuOptionControl : MonoBehaviour {
    /*＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
    ＊＊＊＊＊＊SkillMenuOptionControl.cs＊＊＊＊＊＊
    *＊＊＊メニューのオプションをコントロールする＊＊＊
    ＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊*/
    private int listActionNumber;//スキルのリストの数
    private bool selected;//オプションは選んだらTrueになる
    private int requiredMP;//必要なマジックポイント
    private string optionName;//オプションの名前
    TextMesh textM;//オプションのテクストコンポネント
    int originalFontSize;//最初んのテクストの大きさ
    [SerializeField]
    bool isRecovery;//オプションは回復だったら、Trueになる
    SkillSetControl skillSetsControl;//全部のスキル動作のコントローラー
    StatsControl statsControl;//プレイヤーのステータスのコントローラー

    public bool Selected
    {
        get
        {
            return selected;
        }

        set
        {
            selected = value;
        }
    }
    public int ListActionNumber
    {
        get
        {
            return listActionNumber;
        }

        set
        {
            listActionNumber = value;
        }
    }
    public int RequiredMP
    {
        get
        {
            return requiredMP;
        }

        set
        {
            requiredMP = value;
        }
    }

    void Start () {
        textM = GetComponent<TextMesh>();
        originalFontSize = textM.fontSize;
        if (isRecovery)
        {
            requiredMP = 20;
            ListActionNumber = -2;
        }
        skillSetsControl = GameObject.Find("StatsController").GetComponent<SkillSetControl>();
        statsControl = GameObject.Find("StatsController").GetComponent<StatsControl>();
    }
	
	void Update () {

        if (selected)
        {
            if (requiredMP > statsControl.Mp)
            {
                textM.color = new Color(1f, 0f, 0f);
                textM.fontSize = originalFontSize;
            }
            else
            {
                textM.color = new Color(0.8f, 0.8f, 0.3f);
                textM.fontSize = originalFontSize + 20;
            }
        }
        else {
            textM.color = new Color(1f, 1f, 1f);
            textM.fontSize = originalFontSize;
        }
	}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "CursorSelection" && gameObject.tag!="MenuDownLimit")
        {
            Selected = true;
            skillSetsControl.CurrentSelectedAttack = ListActionNumber;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "CursorSelection")
        {
            skillSetsControl.CurrentSelectedAttack = -1;
            Selected = false;
        }
    }
    //SetUp関数
    //最初の時にセットアップする
    public void SetUp(int listActionNumber, int requiredMP, string optionName)
    {
        gameObject.name = optionName;
        this.ListActionNumber = listActionNumber;
        this.RequiredMP = requiredMP;
        gameObject.tag = "SkillOption";
    }
}
