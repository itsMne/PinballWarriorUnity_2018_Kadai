
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTextureSwappingController : MonoBehaviour
{
    //Textures that will change during the rendering
    [SerializeField]
    private Texture t1;
    [SerializeField]
    private Texture t2;
    [SerializeField]
    private Texture t3;
    [SerializeField]
    private Texture t4;
    int textureToUse;
    [SerializeField]
    private float   timer = 0;
    float           ogtimer;
    Renderer        objectRenderer;
    // Use this for initialization
    void Start()
    {
        if (timer == 0)
        {
            timer = 0.05f;
        }
        ogtimer = 0;
        objectRenderer = this.GetComponent<Renderer>();
        objectRenderer.material.EnableKeyword("_NORMALMAP");
        objectRenderer.material.EnableKeyword("_METALLICGLOSSMAP");
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
            if (textureToUse == 0)
                objectRenderer.material.SetTexture("_MainTex", t1);
            if (textureToUse == 1)
                objectRenderer.material.SetTexture("_MainTex", t2);
            if (textureToUse == 2)
                objectRenderer.material.SetTexture("_MainTex", t3);
            if (textureToUse == 3)
                objectRenderer.material.SetTexture("_MainTex", t4);
            textureToUse++;
            if (textureToUse > 3)
                textureToUse = 0;
            timer = ogtimer;
        }
    }
}
