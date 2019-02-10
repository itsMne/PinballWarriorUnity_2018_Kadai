using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMapControl : MonoBehaviour {
    /******************************
     *****EnemyMapControl.cs*******
     *マップにいる敵のコントローラー*
     *****************************/
    [SerializeField]
    private GameObject pinballMode;//ピンボールバトルのオブジェクト
    [SerializeField]
    private int enemyToInstantiate;//作るつもりの敵
    private bool isDead;//敵は死んだ時、Trueになる。
    EnemyListControl bestiary;//敵のリスト
    BoxCollider bCollider;//ボックスコライダーのコンポネント
    
    public bool IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }
    // Use this for initialization
    void Start () {
        bestiary = pinballMode.GetComponent<EnemyListControl>();
        isDead = false;
        bCollider = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        DeathControl();
    }
    //DeathControl関数
    //HP０になると、オブジェクトを準備する
    private void DeathControl()
    {
        if (IsDead)
        {
            float newX = 0, newY = 0, newZ = 0;
            if (transform.localScale.x > 0)
                newX = 0.035f;
            if (transform.localScale.y > 0)
                newY = 0.035f;
            if (transform.localScale.z > 0)
                newZ = 0.035f;
            transform.localScale -= new Vector3(newX, newY, newZ);
            if (transform.localScale.x <= 0 && transform.localScale.y <= 0 && transform.localScale.z <= 0)
                Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            bestiary.InstantiateEnemy(enemyToInstantiate, this.gameObject);
            bCollider.enabled = false;
            GameObject.Find("TransitionControl").GetComponent<FightTransitionControl>().DoTheTransition();

        }
    }
}
