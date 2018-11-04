using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var oObj = collision.gameObject;
        if (oObj.name == "Player")
        {
            oObj.GetComponent<Inventory>().Clear();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
