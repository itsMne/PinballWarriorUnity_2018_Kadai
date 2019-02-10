using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovementControl : MonoBehaviour {
    /*******************************
     ****CursorMovementControl.cs***
     *メニューの選定をコントロールする*
     *******************************/
    [SerializeField]
    KeyCode UpCursor=KeyCode.I;//メニューのコントロールするキー（上）
    [SerializeField]
    KeyCode DownCursor=KeyCode.K;//メニューのコントロールするキー（下）

    bool canMoveUp;//上のオプションの限定
    bool canMoveDown;//下のオプションの限定
    Vector3 ogPosition;//喧嘩を始める所
    SkillSetControl skillsControl;//プレイヤーのスキルアタック
    // Use this for initialization
    void Start () {
        canMoveUp = true;
        canMoveDown = true;
        ogPosition = transform.localPosition;
        skillsControl = GameObject.Find("StatsController").GetComponent<SkillSetControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!skillsControl.ExecutingMove)
        {
            if (Input.GetAxis("Vertical") < -0.1f && canMoveUp)
            {
                transform.Translate(-Vector3.up * Time.deltaTime * 8);
            }
            if (Input.GetAxis("Vertical") > 0.1f && canMoveDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 8);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "MenuUpLimit")
            canMoveUp = false;
        if (collision.gameObject.tag == "MenuDownLimit")
            canMoveDown = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MenuUpLimit")
            canMoveUp = true;
        if (collision.gameObject.tag == "MenuDownLimit")
            canMoveDown = true;
    }
    //ResetCursorPosition関数
    //セレクションアローは最初の場所に戻る
    public void ResetCursorPosition()
    {
        transform.localPosition = ogPosition;
    }
}
