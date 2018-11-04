using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollisionChecks : MonoBehaviour {
    [System.NonSerialized]
    public bool TouchingElementalInteractable_ = false;
    [System.NonSerialized]
    public bool TouchingPuzzleInteractable_ = false;
    [System.NonSerialized]
    public bool TouchingTeleporterInteractable_ = false;

    // Use this for initialization
    void Start () {
		
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var theType = collision.gameObject.GetComponent<ElementTypes>();
        var theTarget = collision.gameObject.GetComponent<Target>();
        var theTeleporter = collision.gameObject.GetComponent<Teleporter>();
        if (theType)
        {
            TouchingElementalInteractable_ = true;
            var collection = GetComponent<Collection>();
            collection.TempTypes = theType;
            var text = GameObject.Find("ObjectNames");
            text.GetComponent<Text>().text = theType.name_;
        }
        else if(theTarget)
        {
            TouchingPuzzleInteractable_ = true;
            var text = GameObject.Find("ObjectNames");
            text.GetComponent<Text>().text = theTarget.name_;
        }
        else if (theTeleporter)
        {
            TouchingTeleporterInteractable_ = true;
            var collection = GetComponent<Collection>();
            collection.TempPorter = theTeleporter;
            var text = GameObject.Find("ObjectNames");
            text.GetComponent<Text>().text = theTeleporter.name_;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ElementTypes>())
        {
            TouchingElementalInteractable_ = false;
            var text = GameObject.Find("ObjectNames");
            text.GetComponent<Text>().text = "";
        }
        else if (collision.gameObject.GetComponent<Target>())
        {
            TouchingPuzzleInteractable_ = false;
            var text = GameObject.Find("ObjectNames");
            text.GetComponent<Text>().text = "";
        }
        else if (collision.gameObject.GetComponent<Teleporter>())
        {
            TouchingTeleporterInteractable_ = false;
            var text = GameObject.Find("ObjectNames");
            text.GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
