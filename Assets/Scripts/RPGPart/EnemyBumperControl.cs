using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBumperControl : MonoBehaviour {
    /*************************************
　　********EnemyBumperControl.cs*********
　　*******RPGモードの敵をコントロール******
　　*********RPGモードでしか使えない********
　　**************************************/
    CapsuleCollider cCollider;
    [SerializeField]
    private int bumperHP;//敵の体力
    [SerializeField]
    private int bumperDef;//敵の防衛
    [SerializeField]
    private bool mainBumper;//メインバンパー、という喧嘩の一番大切な敵だったら、チェックしなければいけない。
    [SerializeField]
    private int nDefToRemoveToMain;//喧嘩の一番大切な敵じゃなかったら、HPは０になるとメインバンパーの防衛を減らす
    StatsControl playerStats;//プレイヤーのステータスの変数
    private bool isDead;//HPになったら、isDeadはTrueになる。
    BumperControl bControl;//普通のバンパーのコンポネント。HPは0になると、このコンポネントを無効かする。
    [SerializeField]
    private GameObject DeathCamera;//メインバンパーの近いカメラ。HPは0になると、このオブジェクトを活性化する。
    [SerializeField]
    private GameObject spriteRegular;//普通なスプライト。
    [SerializeField]
    private GameObject spriteAttacked;//ダメージをもらったスプライト
    private bool attacked;//ボールとぶつかったら、この変数はTrueになる。
    float timerAttacked;//スプライトを変えることのタイマー
    RPGFightControl fightControl;//RPGモードの喧嘩のコントロール。EXPをあげられるために、この変数は必要である。
    [SerializeField]
    int EXPToGive;//喧嘩が終わった時、EXPをあげる。
    int nMaxHP;//HPの限界
    private int damageDealt;//0じゃなかったら、HPを減らす。

    SkillSetControl skillsControl;
    public int BumperDef
    {
        get
        {
            return bumperDef;
        }

        set
        {
            bumperDef = value;
        }
    }
    public int NMaxHP
    {
        get
        {
            return nMaxHP;
        }

        set
        {
            nMaxHP = value;
        }
    }
    public int BumperHP
    {
        get
        {
            return bumperHP;
        }

        set
        {
            bumperHP = value;
        }
    }
    public int DamageDealt
    {
        get
        {
            return damageDealt;
        }

        set
        {
            damageDealt = value;
        }
    }

    // Use this for initialization
    void Start () {
        playerStats = GameObject.Find("StatsController").GetComponent<StatsControl>();
        fightControl = GameObject.FindGameObjectWithTag("PinballMode").GetComponent<RPGFightControl>();
        bControl = GetComponent<BumperControl>();
        timerAttacked = 0;
        NMaxHP = BumperHP;
        DamageDealt = 0;
        skillsControl = GameObject.Find("StatsController").GetComponent<SkillSetControl>();
        cCollider = GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        HPAndDamageControl();
        DeathControl();
        SpriteAnimationControl();

    }
    //SpriteAnimationControl関数
    //スプライトをコントロールする。
    private void SpriteAnimationControl()
    {
        if (spriteRegular != null && spriteAttacked != null)
        {
            if (attacked)
            {
                spriteRegular.SetActive(false);
                spriteAttacked.SetActive(true);
            }
            else
            {
                spriteRegular.SetActive(true);
                spriteAttacked.SetActive(false);
            }
            if (spriteAttacked.activeInHierarchy)
            {
                timerAttacked += Time.deltaTime;
            }
            if (timerAttacked > 0.8f)
                attacked = false;
        }
    }
    //HPAndDamageControl関数
    //体力とダメージをコントロールする
    private void HPAndDamageControl()
    {
        if (DamageDealt > 0 && !skillsControl.ExecutingMove)
        {
            DamageDealt--;
            BumperHP--;
            GameObject.Find("Score").GetComponent<ScoreUITextControl>().AddPoint(1);
        }
        if (BumperDef < 0)
        {
            bumperDef = 0;
        }
        if (BumperHP <= 0)
        {
            BumperHP = 0;
            isDead = true;
            bControl.enabled = false;
            cCollider.enabled = false;
        }
    }
    //DeathControl関数
    //HPは０になった時、オブジェクトの変数をコントロールする
    private void DeathControl()
    {
        if (isDead)
        {
            float newX = 0, newY = 0, newZ = 0;
            if (transform.localScale.x > 0)
                newX = 0.035f;
            if (transform.localScale.y > 0)
                newY = 0.035f;
            if (transform.localScale.z > 0)
                newZ = 0.035f;
            transform.localScale -= new Vector3(newX, newY, newZ);
            if (!mainBumper)
            {
                if (GameObject.Find("MainBumper"))
                {
                    GameObject.Find("MainBumper").GetComponent<EnemyBumperControl>().BumperDef -= nDefToRemoveToMain;
                }
            }
            else
            {
                if (!fightControl.BattleIsOver)
                {
                    fightControl.ExpForTheFight = EXPToGive;
                    fightControl.BattleIsOver = true;
                }
            }
            if (DeathCamera)
            {
                DeathCamera.SetActive(true);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //BumperHP -= 1+playerStats.Atk+(Random.Range(0,3))-BumperDef;
        DamageDealt += 1+playerStats.Atk+(Random.Range(0,3))-BumperDef;
        skillsControl.SelectedEnemy = this.gameObject;
        skillsControl.ExecuteSkillMove();
        attacked = true;
        timerAttacked = 0;
    }
}
