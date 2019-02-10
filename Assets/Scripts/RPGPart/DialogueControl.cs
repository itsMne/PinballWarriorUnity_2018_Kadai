using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {
    [SerializeField]
    private List<string> displayText;
    private Text text;//Text to display which is separated by "/"
    private int continuedTextCount;
    MoveCharacterControl mcMoveControl;
    //MaoOptionsControl maoControl;
    private bool needToDisplay;
    private bool textWindowIsActive;
    private bool canContinueText;
    public int ContinuedTextCount
    {
        get{return continuedTextCount;}
        set{continuedTextCount = value;}
    }
    public bool TextWindowIsActive
    {
        get
        {
            return textWindowIsActive;
        }

        set
        {
            textWindowIsActive = value;
        }
    }

    public bool CanContinueText
    {
        get
        {
            return canContinueText;
        }

        set
        {
            canContinueText = value;
        }
    }

    // Use this for initialization
    void Start() {
        needToDisplay = false;
        textWindowIsActive = false;
        CanContinueText = true;
        displayText = new List<string>();
        text = this.GetComponent<Text>();
        ContinuedTextCount = 0;
        //maoControl= GameObject.FindGameObjectWithTag("Options").GetComponent<MaoOptionsControl>();
        mcMoveControl = GameObject.Find("Player").GetComponent<MoveCharacterControl>();
    }

    // Update is called once per frame
    void Update() {
        if (needToDisplay)//Need this variable to avoid constantly changing the variable of moving for the main character
        {
            textWindowIsActive = true;
            if (displayText.Count > 0)
            {
                text.text = displayText[0];
                if ((Input.GetButtonDown("Use")) && CanContinueText)
                {
                    displayText.Remove(displayText[0]);
                    ContinuedTextCount++;
                }
            }
            else
            {
                text.text = "";
                ContinuedTextCount = 0;
                mcMoveControl.BCanMove = true;
                //maoControl.CanMove = true;
                //maoControl.MaoBoxCollider.enabled = true;
                needToDisplay = false;
            }
        }//fi
        else {
            textWindowIsActive = false;
        }
    }
    public void Dialogue(string Text)
    {
        //displayText = Text;
        string[] splitArray = Text.Split(char.Parse("/"));
        int cont=0;
        while (cont < splitArray.Length)
        {
            displayText.Add(splitArray[cont]);
            cont++;
        }
        // maoControl.CanMove = false;
        // maoControl.MaoBoxCollider.enabled = false;
        mcMoveControl.BCanMove = false;
        needToDisplay = true;
    }
    public void Dialogue(string Text, bool movement)
    {
        //displayText = Text;
        string[] splitArray = Text.Split(char.Parse("/"));
        int cont = 0;
        while (cont < splitArray.Length)
        {
            displayText.Add(splitArray[cont]);
            cont++;
        }
        mcMoveControl.BCanMove = movement;
        //if (!movement) { maoControl.MaoBoxCollider.enabled = false; }
        needToDisplay = true;
    }
    public void CloseDialogueSuddenly()
    {
        text.text = "";
        ContinuedTextCount = 0;
        //maoControl.CanMove = true;
        //maoControl.MaoBoxCollider.enabled = true;
        needToDisplay = false;
        displayText= new List<string>();
        mcMoveControl.BCanMove = true;
        TextWindowIsActive = false;
    }
}
