using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListControl : MonoBehaviour {
    /****************************
     *****EnemyListControl.cs****
     **敵のリストのコントローラー**
     ****************************/
    [SerializeField]
    private List<GameObject> Enemies;//敵のリスト
    [SerializeField]
    private GameObject enemyOnMap;//マップの敵
    [SerializeField]
    private GameObject instantiatedEnemy;//喧嘩で作った敵

    public GameObject EnemyOnMap
    {
        get
        {
            return enemyOnMap;
        }

        set
        {
            enemyOnMap = value;
        }
    }
    public GameObject InstantiatedEnemy
    {
        get
        {
            return instantiatedEnemy;
        }

        set
        {
            instantiatedEnemy = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //InstantiateEnemy関数
    //敵を作る
    public void InstantiateEnemy(int selectedEnemy, GameObject gHitEnemyOnMap)
    {
        enemyOnMap = gHitEnemyOnMap;
        if (selectedEnemy >= Enemies.Count)
        {
            Debug.Log("敵はリストの中にいない");
            return;
        }
        instantiatedEnemy=Instantiate(Enemies[selectedEnemy], this.transform);
        instantiatedEnemy.SetActive(true);
    }
    //DestroyEnemy関数
    //敵を消す
    public void DestroyEnemy()
    {
        Destroy(instantiatedEnemy);
        enemyOnMap.GetComponent<EnemyMapControl>().IsDead = true;
    }
}
