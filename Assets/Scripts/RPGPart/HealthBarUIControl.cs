using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIControl : MonoBehaviour {
    /********************************
     *****HealthBarUIControl.cs******
     ****敵の体力のUIコントローラー****
     ********************************/
    Image thisUIImage;//UIの画像のコンポネント
    [SerializeField]
    EnemyBumperControl enemyControl;//敵のコントローラー
	// Use this for initialization
	void Start () {
        thisUIImage = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (thisUIImage != null)
        {
            float hpToDisplay = ((float)enemyControl.BumperHP / (float)enemyControl.NMaxHP);
            thisUIImage.fillAmount = hpToDisplay;
        }
        else
        {
            Debug.Log("敵のオブジェクトはNULLである。");
        }
	}
}
