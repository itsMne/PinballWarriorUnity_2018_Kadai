using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsMenuOrganizationControl : MonoBehaviour {
    /***************************************
     ****SkillsMenuOrganizationControl.cs***
     ***スキルのメニューを最初の時に準備する***
     ***************************************/
    [SerializeField]
    private GameObject EndOfMenu;//メニューの最後の部分
    SkillSetControl skillsControl;//スキルのコントローラー
	// Use this for initialization
	void Start () {
        skillsControl = GameObject.Find("StatsController").GetComponent<SkillSetControl>();
        for (int i=0; i < skillsControl.Names.Count; i++)
        {
            if (skillsControl.Obtained[i])
            {
                GameObject newEndOfMenu = Instantiate(EndOfMenu, gameObject.transform);
                newEndOfMenu.transform.localPosition = new Vector3(EndOfMenu.transform.localPosition.x, EndOfMenu.transform.localPosition.y + 15, EndOfMenu.transform.localPosition.z);
                EndOfMenu.GetComponent<TextMesh>().text = "" + skillsControl.Names[i] + "  " + skillsControl.RequiredMP[i];
                EndOfMenu.GetComponent<SkillMenuOptionControl>().SetUp(i, skillsControl.RequiredMP[i], skillsControl.Names[i]);
                EndOfMenu = newEndOfMenu;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
