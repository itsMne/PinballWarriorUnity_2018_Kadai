using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PinballVariablesControl : MonoBehaviour {
    /***************************************
     ******PinballVariablesControl.cs*******
     *ピンボールモードの変数をコントロールする**
     ***************************************/
    [SerializeField]
    private int nHP;//０ならゲームは終わり
    [SerializeField]
    private int maxHP;

    public int NHP
    {
        get
        {
            return nHP;
        }

        set
        {
            nHP = value;
        }
    }
    public int MaxHP
    {
        get
        {
            return maxHP;
        }

        set
        {
            maxHP = value;
        }
    }

    // Use this for initialization
    void Start () {
        if (NHP == 0)
        {
            NHP = 3;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (NHP < 0)
        {
            SceneManager.LoadScene("Results");
        }
        if (NHP > maxHP)
            NHP = maxHP;

    }
}
