using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBumperControl : MonoBehaviour {
    /**********************
     *MoveBumperControl.cs*
     ***バンパーを動かせる***
     **********************/
    [SerializeField]
    int direction;//バンパーの向き
    [SerializeField]
    float speed;//バンパーの速さ
    [SerializeField]
    bool bUpsidedown;//バンパーの動き方（上下）
    [SerializeField]
    bool bSideways;//バンパーの動き方（左右）
    SkillSetControl skillsControl;//RPGモードだったら、スキルのコントローラーを使う
    // Use this for initialization
    void Start () {
        if(direction==0)
            direction = 1;
        if (speed == 0)
            speed = 1;
        if (GameObject.Find("StatsController"))
        {
            skillsControl = GameObject.Find("StatsController").GetComponent<SkillSetControl>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveControl();
    }
    //MoveControl関数
    //動くコントローラー
    private void MoveControl()
    {
        if (skillsControl)
        {
            if (skillsControl.ExecutingMove)//スキルを使う時、バンパーは動けない
            {
                if(skillsControl.CurrentAnimation.activeInHierarchy)
                    return;
            }
                
        }
        if (bUpsidedown)
            transform.Translate(Vector3.forward * Time.deltaTime * direction * speed);
        if (bSideways)
            transform.Translate(Vector3.right * Time.deltaTime * direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LimitBumper")
        {
            direction *= -1;
        }
    }
}
