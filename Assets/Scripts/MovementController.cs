﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField]
    float speed_ = 1.0f;
    Vector2 facing;
	// Use this for initialization
	void Start () {
        facing = Vector2.down;
	}
	
	// Update is called once per frame
	void Update () {
        var movement = Vector2.zero;
        var Hori = Input.GetAxis("Horizontal");
        var Vert = Input.GetAxis("Vertical");
        if (Hori > 0.2f || Hori < -0.2f)
        {
            facing.x = Hori;
            movement.x = Hori;
        }
        if (Vert > 0.2f || Vert < -0.2f)
        {
            facing.y = Vert;
            movement.y = Vert;
        }
        GetComponent<Rigidbody2D>().velocity = movement * speed_;
        
        float angle = Mathf.Atan2(facing.y, facing.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //print(GetComponent<Rigidbody2D>().velocity);
    }
}
