using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [System.NonSerialized]
    public ELEMENTALTYPES SlotOne_ = ELEMENTALTYPES.EMPTY;

    [System.NonSerialized]
    public ELEMENTALTYPES SlotTwo_ = ELEMENTALTYPES.EMPTY;

    [System.NonSerialized]
    public ELEMENTALTYPES SlotThree_ = ELEMENTALTYPES.EMPTY;

    [System.NonSerialized]
    public ELEMENTALTYPES SlotFour_ = ELEMENTALTYPES.EMPTY;

    [System.NonSerialized]
    public ELEMENTALTYPES SlotFive_ = ELEMENTALTYPES.EMPTY;

    [System.NonSerialized]
    public int NextFreeSlot_ = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
