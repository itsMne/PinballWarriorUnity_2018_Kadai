using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReporter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(gameObject.name + "'s currently in Position: (" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ", "+ gameObject.transform.position.z + ") ");
        print(gameObject.name + "'s currently in LocalPosition: (" + gameObject.transform.localPosition.x + ", " + gameObject.transform.localPosition.y + ", " + gameObject.transform.localPosition.z + ") ");
        print(gameObject.name + "'s currently Rotated at: " + gameObject.transform.localRotation);
        //print(gameObject.name + "'s scale: " + gameObject.transform.localScale);
    }
}
