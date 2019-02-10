using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCharacterControl : MonoBehaviour {
    /*******************************
    ****MoveCharacterControl.cs*****
    ****マップでプレイヤーの動き方****
    *******************************/
    //動くことのキー
    /*[SerializeField]
    KeyCode keycodeForward = KeyCode.W;
    [SerializeField]
    KeyCode keycodeBackwards = KeyCode.S;
    [SerializeField]
    KeyCode keycodeRight = KeyCode.D;
    [SerializeField]
    KeyCode keycodeLeft = KeyCode.A;*/
    Rigidbody rbody;//オブジェクトのリジッドボディー
    [SerializeField]
    float speed;//プレイヤーの速さ
    private bool bCanMove;
    CursorLockMode wantedMode;
    [SerializeField]
    private DialogueControl dialogueWindow;
    public bool BCanMove
    {
        get
        {
            return bCanMove;
        }

        set
        {
            bCanMove = value;
        }
    }
    public DialogueControl DialogueWindow
    {
        get
        {
            return dialogueWindow;
        }

        set
        {
            dialogueWindow = value;
        }
    }

    void Start () {
        wantedMode = CursorLockMode.Locked;
        rbody =GetComponent<Rigidbody>();
        if (speed == 0)
            speed = 1;
        SetCursorState();
        bCanMove = true;
    }
    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
    // Update is called once per frame
    void Update ()
    {
        MovementControl();
    }

    private void MovementControl()
    {
        if (!bCanMove)
        {
            rbody.velocity = Vector3.zero;
            return;
        }
        Vector3 Movement = Vector3.zero;
        Movement += transform.right * Time.deltaTime * speed * Input.GetAxis("Horizontal");
        Movement += transform.up * Time.deltaTime * speed * Input.GetAxis("Vertical");
        rbody.MovePosition(transform.position + Movement);
        gameObject.transform.Rotate(Vector3.up * speed * 0.25f * Input.GetAxis("Mouse X"), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PitDeath")
        {
            SceneManager.LoadScene("Title");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall" || collision.gameObject.name == "Wizard") 
        {
            rbody.velocity = Vector3.zero;
        }
    }
}
