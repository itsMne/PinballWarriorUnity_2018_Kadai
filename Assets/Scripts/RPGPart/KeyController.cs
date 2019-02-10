using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

    LocationsController lController;
    [SerializeField]
    int UnlockCode;
	// Use this for initialization
	void Start () {
        lController = GameObject.Find("Locations").GetComponent<LocationsController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            lController.UnLockedDoors[UnlockCode] = true;
            Destroy(this.gameObject);
        }
    }
}
