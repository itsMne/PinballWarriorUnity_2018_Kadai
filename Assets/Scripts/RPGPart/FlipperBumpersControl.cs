using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBumpersControl : MonoBehaviour {
    /****************************************
    ********FlipperBumpersControl.cs*********
    **フリッパーの小さいバンパーをコントロール**
    *********RPGモードでしか使えない**********
    *****************************************/
    StatsControl statsControl;//小さいバンパーのHP
    SpriteRenderer spriteControl;//小さいバンパーのスプライト
    [SerializeField]
    private char flipperSide;//何のフリッパーのバンパー（左 - L か 右 - R）
    bool needsRecovery;//HPは０だったら、タイマーで回復する。
    float timer;//回復のタイマー
    CapsuleCollider cCollider;//オブジェクトのコライダー
	// Use this for initialization
	void Start () {
        statsControl = GameObject.Find("StatsController").GetComponent<StatsControl>();
        cCollider = GetComponent<CapsuleCollider>();
        if (transform.childCount > 0)
        {
            spriteControl = transform.GetChild(0).GetComponent<SpriteRenderer>();
        }
        needsRecovery = false;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (needsRecovery) {
            timer += Time.deltaTime;
        }

        if (timer > 20 && needsRecovery)
        {
            ReviveFlipper();
        }
        if ((statsControl.SmallFlipperBumpersLeftHP <= 0 && flipperSide == 'L') || (statsControl.SmallFlipperBumpersRightHP <= 0 && flipperSide == 'R'))
        {
            KillFlipper();
        }
    }
    //KillFlipper関数
    //HPは０になると、回復に待てるために、オブジェクトの変数を準備する。
    private void KillFlipper()
    {
        spriteControl.color = new Color(spriteControl.color.r, spriteControl.color.g, spriteControl.color.b, 0.5f);
        needsRecovery = true;
        cCollider.enabled = false;
    }
    //Revive関数
    //タイマーは２０になると、回復を始めるために、オブジェクトの変数を準備する。
    private void ReviveFlipper()
    {
        timer = 0;
        cCollider.enabled = true;
        spriteControl.color = new Color(spriteControl.color.r, spriteControl.color.g, spriteControl.color.b, 1);
        needsRecovery = false;
        if (flipperSide == 'L')
            statsControl.SmallFlipperBumpersLeftHP = statsControl.SmallFlipperBumpersLeftHPMax;
        if (flipperSide == 'R')
            statsControl.SmallFlipperBumpersRightHP = statsControl.SmallFlipperBumpersRightHPMax;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (flipperSide == 'L')
            statsControl.SmallFlipperBumpersLeftHP--;
        if (flipperSide == 'R')
            statsControl.SmallFlipperBumpersRightHP--;
    }
}
