using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public string name_ = "Temp";
    public Vector2 targetPoint = Vector2.zero;
	// Use this for initialization
	void Start () {
		
	}
	
    public void Teleport()
    {
        var player = GameObject.Find("Player");
        var pos = player.transform.position;
        pos.x = targetPoint.x;
        pos.y = targetPoint.y;
        player.transform.position = pos;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
