using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*********************************
 ***********StatsControl.cs*******
 *プレイヤーのステータスに関する変数*
 *********************************/

public class StatsControl : MonoBehaviour {
    private int lvl;//プレイヤーのレベル
    private int smallFlipperBumpersRightHP;//右の小さいバンパーのHP
    private int smallFlipperBumpersLeftHP;//左の小さいバンパーのHP
    private int smallFlipperBumpersRightHPMax;//右の小さいバンパーのHPの限界
    private int smallFlipperBumpersLeftHPMax;//右の小さいバンパーのHPの限界
    private int atk;//プレイヤーの攻撃
    [SerializeField]
    private int mp;//プレイヤーのマジックポイント
    private int mpMAX;//プレイヤーのマジックポイントの限界
    [SerializeField]
    private int nEXP;//EXPの変数
    private int nNextEXP;//次のレベルの必要なEXP
    float fLevelUpTextTimer;//レベルアップの表面のタイマー
    bool bLevelUPPed;//レベルアップの表面を表すコントロールする
    [SerializeField]
    GameObject gLevelUpText;//レベルアップの表面

    [SerializeField]
    List<GameObject> AllEnemies;

    public int Atk
    {
        get
        {
            return atk;
        }

        set
        {
            atk = value;
        }
    }
    public int Mp
    {
        get
        {
            return mp;
        }

        set
        {
            mp = value;
        }
    }
    public int Lvl
    {
        get
        {
            return lvl;
        }

        set
        {
            lvl = value;
        }
    }
    public int NEXP
    {
        get
        {
            return nEXP;
        }

        set
        {
            nEXP = value;
        }
    }
    public int NNextEXP
    {
        get
        {
            return nNextEXP;
        }

        set
        {
            nNextEXP = value;
        }
    }
    public int SmallFlipperBumpersRightHP
    {
        get
        {
            return smallFlipperBumpersRightHP;
        }

        set
        {
            smallFlipperBumpersRightHP = value;
        }
    }
    public int SmallFlipperBumpersLeftHP
    {
        get
        {
            return smallFlipperBumpersLeftHP;
        }

        set
        {
            smallFlipperBumpersLeftHP = value;
        }
    }
    public int SmallFlipperBumpersRightHPMax
    {
        get
        {
            return smallFlipperBumpersRightHPMax;
        }

        set
        {
            smallFlipperBumpersRightHPMax = value;
        }
    }
    public int SmallFlipperBumpersLeftHPMax
    {
        get
        {
            return smallFlipperBumpersLeftHPMax;
        }

        set
        {
            smallFlipperBumpersLeftHPMax = value;
        }
    }

    // Use this for initialization
    void Start () {
        Lvl = 1;
        SmallFlipperBumpersRightHP = 20;
        SmallFlipperBumpersLeftHP = 20;
        smallFlipperBumpersRightHPMax = SmallFlipperBumpersRightHP;
        smallFlipperBumpersLeftHPMax = SmallFlipperBumpersLeftHP;
        Atk = 1;
        Mp = 20;
        mpMAX = mp;
        NEXP = 0;
        NNextEXP = 10;
        fLevelUpTextTimer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (mp > mpMAX)
        {
            mp = mpMAX;
        }
        LevelUpControl();
    }
    //LevelUpControl関数
    //レベルアップの時、変数をコントロールする
    private void LevelUpControl()
    {
        if (nEXP >= nNextEXP)
        {
            nNextEXP = nNextEXP + (int)(nNextEXP * 2.5f);
            Lvl++;
            Atk += 2;
            mpMAX += 5;
            mp = mpMAX;
            SmallFlipperBumpersRightHP += 5;
            SmallFlipperBumpersLeftHP += 5;
            bLevelUPPed = true;
            fLevelUpTextTimer = 0;
        }
        if (bLevelUPPed)
        {
            fLevelUpTextTimer += Time.deltaTime;
            if (fLevelUpTextTimer < 6)
            {
                gLevelUpText.SetActive(true);
            }
            else
            {
                gLevelUpText.SetActive(false);
            }
        }
    }
}
