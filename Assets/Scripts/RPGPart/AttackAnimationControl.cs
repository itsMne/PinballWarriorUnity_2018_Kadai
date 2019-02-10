using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationControl : MonoBehaviour {
    /******************************************
     *********AttackAnimationControl.cs********
     *スキルの動作のアニメーションのコントローラー*
     ******************************************/
    private Animator animator;//アニメーターのコンポネント
    [SerializeField]
    private string animationName;//アニメーションの名前
    private bool animationPlayed;//アニメーションが終わったら、Trueになる

    public bool AnimationPlayed
    {
        get
        {
            return animationPlayed;
        }

        set
        {
            animationPlayed = value;
        }
    }
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
        {
            AnimationPlayed = false;
        }
        else {
            AnimationPlayed = true;
        }
    }
}
