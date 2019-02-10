using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTransitionControl : MonoBehaviour {
    /****************************************
     *******FightTransitionControl.cs********
     *マップからピンボールバトルまで変え方と逆さ*
     ****************************************/
    [SerializeField]
    GameObject Pinball;//ピンボールバトルのオブジェクト。
    [SerializeField]
    GameObject RPGWorld;//RPGマップのオブジェクト。
    [SerializeField]
    GameObject SkillMenu;//スキルのメニューのオブジェクト。
    [SerializeField]
    bool isInFight;//ファイトなら、Trueになる。
    EnemyListControl bestiary;//敵のリスト。
    RPGFightControl fightControl;//喧嘩のコントローラー。
    GameObject currentMenuActive;//使っているスキルメニュー。
    // Use this for initialization
    void Start () {
        isInFight = false;
        bestiary = Pinball.GetComponent<EnemyListControl>();
        fightControl = Pinball.GetComponent<RPGFightControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isInFight)
        {
            RPGWorld.SetActive(false);
            Physics.gravity = new Vector3(0, 0, -9.81f);
            Pinball.SetActive(true);
        }
        else {
            Pinball.SetActive(false);
            Physics.gravity = new Vector3(0, -9.81f, 0);
            RPGWorld.SetActive(true);
            if (bestiary.EnemyOnMap != null)
            {
                bestiary.DestroyEnemy();
            }
        }
	}
    //DoTheTransition関数
    //マップからピンボールバトルまで変え方と逆さのコントローラー
    public void DoTheTransition()
    {
        if (isInFight)
        {
            isInFight = false;
            Destroy(currentMenuActive);
            return;
        }
        else{
            fightControl.BattleIsOver = false;
            fightControl.InstantiateFlippers();
            currentMenuActive = Instantiate(SkillMenu);
            currentMenuActive.SetActive(true);
            isInFight = true;
            return;
        }
    }
}
