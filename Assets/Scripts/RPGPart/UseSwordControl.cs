using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSwordControl : MonoBehaviour {
    /**************************
     ****UseSwordControl.cs****
     **武器を使うコントローラー**
     **************************/
    Animator animator;//アニメーターのコントローラー
    [SerializeField]
    BoxCollider bCollider;//ボックスコライダーのコンポネント
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            animator.Play("Attack");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime> 0.3933122f &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5862653f)//アニメーションはこの時だったら、ボックスコライダーを使う
        {
            bCollider.enabled = true;
        }
        else
        {
            bCollider.enabled = false;
        }
	}
}
