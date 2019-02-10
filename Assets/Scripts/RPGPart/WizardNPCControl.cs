using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardNPCControl : MonoBehaviour {
    [SerializeField]
    DialogueControl dialogueWindow;
    [SerializeField]
    int nMagicToUnlock;
    float coolDown;
    SkillSetControl statsControl;
    [SerializeField]
    Texture tEyesOpen;
    [SerializeField]
    Texture tEyesClosed;

    Renderer Child1;
    Renderer Child2;
    // Use this for initialization
    void Start () {
        dialogueWindow = GameObject.Find("Player").GetComponent<MoveCharacterControl>().DialogueWindow;
        statsControl = GameObject.Find("StatsController").GetComponent<SkillSetControl>();
        coolDown = 0;
        Child1 = transform.GetChild(0).GetComponent<Renderer>();
        Child2 = transform.GetChild(1).GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (coolDown > 0)
            coolDown-=Time.deltaTime;
        if (dialogueWindow.TextWindowIsActive)
        {
            coolDown = 2;
        }

        if (!statsControl.Obtained[nMagicToUnlock])
        {
            Child1.material.mainTexture = tEyesClosed;
            Child2.material.mainTexture = tEyesClosed;
        }
        else
        {
            Child1.material.mainTexture = tEyesOpen;
            Child2.material.mainTexture = tEyesOpen;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && Input.GetButton("Use") && !dialogueWindow.TextWindowIsActive && coolDown<=0)
        {
            if (!statsControl.Obtained[nMagicToUnlock])
            {
                dialogueWindow.Dialogue("/ピンボール戦士さま、ごきげんよう。/冒険を続ける為に魔法のスキルを開錠させてあげますわ。/「新しいスキルを覚えた」/気をつけてください、ピンボール戦士さま。", false);
                statsControl.Obtained[nMagicToUnlock] = true;
            }
            else {
                dialogueWindow.Dialogue("/気をつけてください、ピンボール戦士さま。", false);
            } 
        }
    }
}
