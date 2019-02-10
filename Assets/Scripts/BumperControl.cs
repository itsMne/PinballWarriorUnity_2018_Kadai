using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************
 ***BumperControl.cs***
 *バンパーのコントロール*
 **********************/
public class BumperControl : MonoBehaviour {

    [SerializeField]
    private float power;//バンパーの力
    [SerializeField]
    private int scoreToAdd;//バンパーとぶつかった後、スコアを上げる数である。
    [SerializeField]
    bool givesMP;//RPGモードだったら、ぶつかった後、MPを上げるオプションが出来る
    Vector3 ogScale;
	// Use this for initialization
	void Start () {
        ogScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.z > ogScale.z)
        {
            transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            transform.localScale = new Vector3(transform.localScale.x, ogScale.y, transform.localScale.z);
        }
        else {
            transform.localScale = ogScale;
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        //Vector3 vel = collision.gameObject.GetComponent<Rigidbody>().velocity;
        Vector3 vel = (collision.transform.position - transform.position).normalized * power;
        if (vel == Vector3.zero)
        {
            vel = new Vector3(1, 1, 1);
        }
        collision.rigidbody.AddForce(vel);
        transform.localScale = transform.localScale + transform.localScale*(0.25f);
        transform.localScale = new Vector3(transform.localScale.x, ogScale.y, transform.localScale.z);
        GameObject.Find("Score").GetComponent<ScoreUITextControl>().AddPoint(scoreToAdd);
        if (givesMP)
        {
            GameObject.Find("MP_UI").GetComponent<ScoreUITextControl>().ScaleUp=true;
            GameObject.Find("StatsController").GetComponent<StatsControl>().Mp++;
        }
    }
}
