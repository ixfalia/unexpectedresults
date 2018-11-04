using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefillInventory : MonoBehaviour {
    [SerializeField]
    string target_ = "";
    [SerializeField]
    List<ElementTypes> lists_ = new List<ElementTypes>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            for(int i= 0; i < lists_.Count;++i)
            {
                GameObject.Find(target_).GetComponent<Inventory>().list_.Add(lists_[i]);
            }
            
        }
	}
}
