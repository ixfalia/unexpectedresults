using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [System.NonSerialized]
    public List<ElementTypes> list_ = new List<ElementTypes>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var text = GameObject.Find("Inventory");
        text.GetComponent<Text>().text = null;
        for (int i = 0; i < list_.Count; ++i)
        {
            text.GetComponent<Text>().text += list_[i].name_;
            if(i+1 < list_.Count)
            {
                text.GetComponent<Text>().text += ", ";
                
            }
        }
        
    }

    public void Clear()
    {
        list_.Clear();
    }
}
