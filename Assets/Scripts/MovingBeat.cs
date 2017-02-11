﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBeat : MonoBehaviour {

    // Game Object is itself

    [Range(0,500)]
    public float RateOfTravel;

    public Vector3 StartPosition;

    // Just in case the middle changes from 0,0
    public GameObject Middle;
    

	// Use this for initialization
	void Start () {
        transform.position = StartPosition;
        transform.LookAt(Middle.transform);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float step = RateOfTravel * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Middle.transform.position, step);
    }
}
