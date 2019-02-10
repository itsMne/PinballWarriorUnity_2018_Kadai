using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonControl : MonoBehaviour {
    /*******************************
     *****TitleButtonControl.cs*****
     **タイトルボタンのコントローラー**
     *******************************/
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameReset()
    {
        SceneManager.LoadScene("Title");
    }
    public void GameeStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void RPGStart()
    {
        SceneManager.LoadScene("RPGMode");
    }
    public void GameEnd()
    {
        //Unityエディター上かどうか
        #if UNITY_EDITOR
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
        {
            //（Exe実行中なら）アプリケーションが終了
            Application.Quit();
        }
        #endif
    }
    
}
