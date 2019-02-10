using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryControl : MonoBehaviour {
    /*********************************
     *********RetryControl.cs*********
     *ボールを落とした時のコントローラー*
     *********************************/
    PinballVariablesControl pVariables;
	// Use this for initialization
	void Start () {
        pVariables = GameObject.FindGameObjectWithTag("PinballMode").GetComponent<PinballVariablesControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //ボールがぶつかった実行
    void OnCollisionEnter(Collision collision)
    {
        pVariables.NHP--;
        collision.rigidbody.velocity = Vector3.zero;
        collision.gameObject.GetComponent<LockAxisBallControl>().ResetPosition();
    }
}
