using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecks : MonoBehaviour {
    [System.NonSerialized]
    public bool TouchingInteractable_ = false;

	// Use this for initialization
	void Start () {
		
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var theType = collision.gameObject.GetComponent<ElementTypes>();
        if (theType)
        {
            TouchingInteractable_ = true;
            var collection = GetComponent<Collection>();
            collection.TempTypes = theType;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ElementTypes>())
        {
            TouchingInteractable_ = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
