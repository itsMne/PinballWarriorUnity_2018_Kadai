using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalExitControl : MonoBehaviour {

    [SerializeField]
    GameObject WhiteCurtainObj;
    Image sWhiteCurtain;
    MoveCharacterControl mcMoveControl;
    bool activateCurtain;
	// Use this for initialization
	void Start () {
        sWhiteCurtain = WhiteCurtainObj.GetComponent<Image>();
        mcMoveControl = GameObject.Find("Player").GetComponent<MoveCharacterControl>();
        activateCurtain = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (activateCurtain)
        {
            float newA = sWhiteCurtain.color.a;
            newA += 0.0025f;
            sWhiteCurtain.color = new Color(sWhiteCurtain.color.r, sWhiteCurtain.color.g, sWhiteCurtain.color.b, newA);
            print(newA);
            if(newA>1.35f)
                SceneManager.LoadScene("End");
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            mcMoveControl.BCanMove = false;
            activateCurtain = true;
        }
    }
}
