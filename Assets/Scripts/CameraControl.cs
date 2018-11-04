using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    [SerializeField]
    GameObject targetPlayer;

    [SerializeField]
    float LeftAndRight_ = 0.0f;
    [SerializeField]
    float TopAndBottom_ = 0.0f;
    [SerializeField]
    float MinCheck_ = 0.01f;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 camAdjustment = Vector2.zero;
        var pos = transform.position;
        var pPos = targetPlayer.transform.position;
        if (pPos.x > pos.x + MinCheck_ && pos.x < LeftAndRight_)
        {
            camAdjustment.x = 0.1f * ((pPos.x - pos.x)/2);
        }
        else if (pPos.x < pos.x - MinCheck_ && pos.x > -LeftAndRight_)
        {
            camAdjustment.x = 0.1f * ((pPos.x - pos.x)/2);
        }
        if (pPos.y > pos.y + MinCheck_ && pos.y < TopAndBottom_)
        {
            camAdjustment.y = 0.1f * ((pPos.y - pos.y)/2);
        }
        else if (pPos.y < pos.y - MinCheck_ && pos.y > -TopAndBottom_)
        {
            camAdjustment.y = 0.1f * ((pPos.y - pos.y)/2);
        }
        pos.x += camAdjustment.x;
        pos.y += camAdjustment.y;
        //print(pos);
        transform.position = pos;
    }
}
