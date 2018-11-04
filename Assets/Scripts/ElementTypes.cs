using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELEMENTALTYPES { EMPTY, PLANTS, ANIMALS, CELESTIALS, FOOD, TOOLS, SOUNDS, LIGHTS, ARTS, EMOTIONS, ACTIVITIES, VEHICLE};

public class ElementTypes : MonoBehaviour {
    public string name_ = "Temp";
    public List<ELEMENTALTYPES> TypeList_ = new List<ELEMENTALTYPES>();
    public Sprite Icon_;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
