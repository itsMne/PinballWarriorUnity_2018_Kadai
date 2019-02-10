using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsController : MonoBehaviour {
    [SerializeField]
    private List<GameObject> Locations;
    [SerializeField]
    private List<bool> unLockedDoors;
    private int currentLocation;
    [SerializeField]
    private int newLocation;

    public int NewLocation
    {
        get
        {
            return newLocation;
        }

        set
        {
            newLocation = value;
        }
    }

    public List<bool> UnLockedDoors
    {
        get
        {
            return unLockedDoors;
        }

        set
        {
            unLockedDoors = value;
        }
    }

    // Use this for initialization
    void Start () {
        currentLocation = -1
            ;
    }
	
	// Update is called once per frame
	void Update () {
        if (NewLocation != currentLocation)
        {
            for (int i = 0; i < Locations.Count; i++)
            {
                if (i != NewLocation)
                {
                    Locations[i].SetActive(false);
                    continue;
                }
                else
                {
                    Locations[i].SetActive(true);
                }
            }
            NewLocation = currentLocation;
        }
	}
}
