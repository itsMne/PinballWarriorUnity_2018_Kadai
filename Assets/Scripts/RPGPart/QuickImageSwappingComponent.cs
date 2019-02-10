using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
using UnityEngine;

public class QuickImageSwappingComponent : MonoBehaviour
{
    /*********************************************
     *************QuickImageSwappingComponent.cs**************
     **タイマーによってスプライトを変える**
     *********************************************/
    //使うスプライト
    [SerializeField]
    private Sprite s1;
    [SerializeField]
    private Sprite s2;
    [SerializeField]
    private Sprite s3;
    [SerializeField]
    private Sprite s4;
    private int ImageToUse;//スプライトの数
    [SerializeField]
    private float timer = 0;//スプライトのタイマー
    float ogtimer;//タイマーの限定のコントローラーである。
    SpriteRenderer image;//スプライトのコンポネント
    // Use this for initialization
    void Start()
    {
        if (timer == 0)
        {
            timer = 0.05f;
        }
        ogtimer = 0;
        image = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ogtimer == 0)
        {
            ogtimer = timer;
        }
        timer -= Time.deltaTime;
        if (timer < 0)//Timer that points to the renderer when to change textures.
        {
            if (ImageToUse == 0)
                image.sprite = s1;
            if (ImageToUse == 1)
                image.sprite = s2;
            if (ImageToUse == 2)
                image.sprite = s3;
            if (ImageToUse == 3)
                image.sprite = s4;
            ImageToUse++;
            if (ImageToUse > 3)
                ImageToUse = 0;
            timer = ogtimer;
        }
    }
}
