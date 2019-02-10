using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    /**************************
     *****FollowBall.cs********
     *カメラはボールの場所を探す*
     **************************/
    [SerializeField]
    GameObject ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y+4, ball.transform.position.z-4);
	}
}
