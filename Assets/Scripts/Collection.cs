using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {
    [System.NonSerialized]
    public ELEMENTALTYPES TempType_ = ELEMENTALTYPES.EMPTY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Fire2") > 0.1 && GetComponent<CollisionChecks>().TouchingInteractable_ == true)
        {
            var inventory = GetComponent<Inventory>();
            var checker = inventory.NextFreeSlot_;

            if(checker == 0)
            {
                inventory.SlotOne_ = TempType_;
            }
            else if (checker == 1)
            {
                inventory.SlotTwo_ = TempType_;
            }
            else if (checker == 2)
            {
                inventory.SlotThree_ = TempType_;
            }
            else if (checker == 3)
            {
                inventory.SlotFour_ = TempType_;
            }
            else if (checker == 4)
            {
                inventory.SlotFive_ = TempType_;
            }
            ++checker;
            if(checker > 4)
            {
                checker = 0;
            }
            inventory.NextFreeSlot_ = checker;
        }
	}
}
