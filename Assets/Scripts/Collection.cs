using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {
    [System.NonSerialized]
    public ElementTypes TempTypes = null;
    [System.NonSerialized]
    public Teleporter TempPorter = null;
    bool FirstCheck = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire2") > 0.1 && FirstCheck && GetComponent<CollisionChecks>().TouchingElementalInteractable_ == true)
        {
            var inventory = GetComponent<Inventory>();
            bool isGoodToAdd = true;
            for (int i = 0; i < inventory.list_.Count; ++i)
            {
                if (TempTypes.name_ == inventory.list_[i].name_)
                {
                    isGoodToAdd = false;
                }
            }
            if (isGoodToAdd)
            {
                inventory.list_.Add(TempTypes);
            }
            FirstCheck = false;
        }
        else if (Input.GetAxis("Fire2") > 0.1 && FirstCheck && GetComponent<CollisionChecks>().TouchingTeleporterInteractable_ == true)
        {
            TempPorter.Teleport();
        }
        else if (Input.GetAxis("Fire2") < 0.1)
        {
            FirstCheck = true;
        }
	}
}
