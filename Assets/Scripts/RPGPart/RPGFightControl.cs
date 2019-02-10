using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGFightControl : MonoBehaviour {
    /*********************************************
     *************RPGFightControl.cs**************
     **RPGの戦闘と戦闘に関する変数をコントロールする**
     *********************************************/
    [SerializeField]
    private GameObject resultsScreen;//喧嘩は終わった後の表面
    private bool battleIsOver;//喧嘩は終わったら、Trueになる。
    private LockAxisBallControl ballControl;//ボールのアクシスのコントローラー
    private int expForTheFight;//もらったEXP 
    float timerForResultsScreen;//終わりの表面のタイマー
    StatsControl playerStats;//プレイヤーのステータスのコンポネント
    FightTransitionControl transitionControl;//喧嘩とマップの変え方をコントロールする
    [SerializeField]
    private GameObject FlippersToInstantiate;//フリッパを作る為に、オリジナルのオブジェクトは必要である。
    GameObject instantiatedFlipper;//作ったフリッパである。

    public bool BattleIsOver
    {
        get
        {
            return battleIsOver;
        }

        set
        {
            battleIsOver = value;
        }
    }
    public int ExpForTheFight
    {
        get
        {
            return expForTheFight;
        }

        set
        {
            expForTheFight = value;
        }
    }

    // Use this for initialization
    void Start () {
        ballControl = GameObject.Find("Ball").GetComponent<LockAxisBallControl>(); ;
        ExpForTheFight = 0;
        timerForResultsScreen = 0;
        playerStats = GameObject.Find("StatsController").GetComponent<StatsControl>();
        if(GameObject.Find("TransitionControl")!=null)
            transitionControl = GameObject.Find("TransitionControl").GetComponent<FightTransitionControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (battleIsOver)
        {
            ballControl.ResetPosition();
            timerForResultsScreen += Time.deltaTime;
            Destroy(instantiatedFlipper);
            if (timerForResultsScreen > 3f)
            {
                resultsScreen.SetActive(true);
            }
            if (resultsScreen.activeInHierarchy)
            {
                //EXPをあげる
                if (ExpForTheFight > 0 && timerForResultsScreen >4.5f)
                {
                    playerStats.NEXP++;
                    ExpForTheFight--;
                }
                else
                {
                    if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Use")) && transitionControl!=null && timerForResultsScreen>6.5f)
                    {
                        transitionControl.DoTheTransition();
                    }
                }
            }
        }
        else
        {
            timerForResultsScreen = 0;
            resultsScreen.SetActive(false);
        }
	}
    public void InstantiateFlippers()
    {
        instantiatedFlipper=Instantiate(FlippersToInstantiate, this.transform);
        instantiatedFlipper.SetActive(true);
    }
}
