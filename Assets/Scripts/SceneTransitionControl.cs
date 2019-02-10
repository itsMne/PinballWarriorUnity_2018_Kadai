using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControl : MonoBehaviour {
    /********************************
     ****SceneTransitionControl.cs***
     ***シーンを変えるコントローラー***
     *******************************/
    [SerializeField]
    private string SceneName;//シーンの名前
    [SerializeField]
    private string buttonName;//ゲームコントローラーのボタンの名前

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton(buttonName))
            SceneManager.LoadScene(SceneName);
    }
}
