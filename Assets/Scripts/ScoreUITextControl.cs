using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUITextControl : MonoBehaviour {
    public static int totalScore;
    /********************************************
     ***********ScoreUITextControl.cs************
     **スコアのコントロールとUIのコントロールである**
     ********************************************/
    Text thisText;//UIのテクスト
    RectTransform rectTransform;//テクストのサイズと場所
    [SerializeField]
    Vector3 originalPosition;//最初の時の所
    [SerializeField]
    Vector3 originalScale;//最初の時の大きさ
    [SerializeField]
    bool scaleUp;//大きくなる時、Trueになる。
    bool scaleDown;//小さいなる時、Trueになる。
    float ScaleUpTimer;//大きくなるタイマー
    [SerializeField]
    bool showsMP;//スコアじゃなかったら、マジックポイントである。
    StatsControl statsControl;//プレイヤーのステータスのコントローラー
    [SerializeField]
    bool changesInSize;
    public bool ScaleUp
    {
        get
        {
            return scaleUp;
        }

        set
        {
            scaleUp = value;
        }
    }

    // Use this for initialization
    void Start () {
        totalScore = 0;
        thisText = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.transform.localPosition;
        originalScale = rectTransform.localScale;
        if (showsMP)
            statsControl = GameObject.Find("StatsController").GetComponent<StatsControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (showsMP)
        {
            thisText.text = "MP: " + statsControl.Mp;
        }
        if (ScaleUpTimer > 1)
        {
            ScaleUp = false;
            ScaleUpTimer = 0;
        }
        if (scaleDown) {
            rectTransform.transform.localPosition -= new Vector3(6f, 0, 0);
            rectTransform.transform.localScale -= new Vector3(0.07f, 0.07f, 0.07f);
            if (rectTransform.transform.localPosition.x <= originalPosition.x)
                scaleDown = false;
        }
        if (ScaleUp)
        {
            ScaleUpTimer += Time.deltaTime;
            if (rectTransform.transform.localPosition.x > originalPosition.x + 40)
            {
                ScaleUp = false;
                scaleDown = true;
                ScaleUpTimer = 0;
            }
                
            rectTransform.transform.localPosition += new Vector3(6f, 0, 0);
            rectTransform.transform.localScale += new Vector3(0.07f, 0.07f, 0.07f);
        }
    }
    public void AddPoint(int score)
    {
        totalScore += score;
        if (!showsMP)
        {
            thisText.text = "得点: " + (int)(totalScore);
            //thisText.text = "";
        }
        if(changesInSize)
            ScaleUp = true;
    }
    public static int GetPoint()
    {
        return totalScore;
    }
}
