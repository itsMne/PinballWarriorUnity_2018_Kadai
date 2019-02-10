using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSwitcherController : MonoBehaviour {

    GameObject Player;
    LocationsController lController;
    [SerializeField]
    private Vector3 newLocationPosition;
    [SerializeField]
    private int newLocationCode;
    [SerializeField]
    int lockCode;
    float coolDown;
    DialogueControl dialogueWindow;
    // Use this for initialization
    void Start () {

        dialogueWindow = GameObject.Find("Player").GetComponent<MoveCharacterControl>().DialogueWindow;
        lController = GameObject.Find("Locations").GetComponent<LocationsController>();
        Player = GameObject.Find("Player");
        coolDown = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (coolDown > 0)
            coolDown -= Time.deltaTime;
        if (dialogueWindow.TextWindowIsActive)
        {
            coolDown = 2;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Use") && other.name=="Player")
        {
            if (lController.UnLockedDoors[lockCode] == true)
            {
                lController.NewLocation = newLocationCode;
                Player.transform.localPosition = newLocationPosition;
            }
            else {
                if(coolDown <= 0)
                    dialogueWindow.Dialogue("/「鍵がかかっている」。", false);
            }
        }
    }
}
