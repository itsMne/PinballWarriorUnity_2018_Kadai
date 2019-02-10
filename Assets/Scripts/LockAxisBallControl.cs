using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxisBallControl : MonoBehaviour {
    /*****************************
     ****LockAxisBallControl.cs***
     ***アクシスをロックするクラス**
     *****************************/
     //ロックしたいアクシス（Trueならロックする）
    [SerializeField]
    private bool bXAxis;
    [SerializeField]
    private bool bYAxis;
    [SerializeField]
    private bool bZAxis;
    //最初の時の場所
    float startingxAxis;
    float startingyAxis;
    float startingzAxis;

    public bool BXAxis
    {
        get
        {
            return bXAxis;
        }

        set
        {
            bXAxis = value;
        }
    }
    public bool BYAxis
    {
        get
        {
            return bYAxis;
        }

        set
        {
            bYAxis = value;
        }
    }
    public bool BZAxis
    {
        get
        {
            return bZAxis;
        }

        set
        {
            bZAxis = value;
        }
    }

    // Use this for initialization
    void Start () {
        startingxAxis = transform.position.x;
        startingyAxis = transform.position.y;
        startingzAxis = transform.position.z;
    }

    // Update is called once per frame
    void Update () {
        if (GetComponent<Rigidbody>().velocity.x == 0 && GetComponent<Rigidbody>().velocity.y == 0 && GetComponent<Rigidbody>().velocity.z == 0)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down*3);
        }
        if (BXAxis)
            transform.position = new Vector3(startingxAxis, transform.position.y, transform.position.z);
        if (BYAxis)
            transform.position = new Vector3(transform.position.x, startingyAxis, transform.position.z);
        if (BZAxis)
            transform.position = new Vector3(transform.position.x, transform.position.y, startingzAxis);
    }
    //ResetPosition関数
    //ボールの最初の場所に戻る
    public void ResetPosition()
    {
        this.transform.position = new Vector3(startingxAxis, startingyAxis, startingzAxis);
    }
}
