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
    float MinCheck_ = 0.1f;
	// Use this for initialization
	void Start () {
        Vector2 camAdjustment = Vector2.zero;
        var pos = transform.position;
        var pPos = targetPlayer.transform.position;
        if (pPos.x > pos.x + MinCheck_ && pos.x < LeftAndRight_)
        {
            camAdjustment.x = 1.0f * (pPos.x - pos.x);
        }
        else if(pPos.x < pos.x - MinCheck_ && pos.x > -LeftAndRight_)
        {
            camAdjustment.x = -1.0f * (pPos.x - pos.x);
        }
        pos.x += camAdjustment.x;
        transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
