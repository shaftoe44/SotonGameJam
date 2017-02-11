﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBeat : MonoBehaviour {

    // Game Object is itself

    [Range(0,500)]
    public float RateOfTravel;

    float timeofdeath;

    public Vector3 StartPosition;

    public int increment;

    // 0, 36, 72, 108, 144, 180, 216, 252, 288, 324
    public List<int> laneAngles = new List<int>();

    float journeyLength;

    float startTime;

    // Just in case the middle changes from 0,0
    public GameObject Middle;

    int selectedAngle;
    

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        transform.position = StartPosition;

        for (int i = 0; i < 359; i += increment)
        {
            laneAngles.Add(i);
        }

        selectedAngle = Random.Range(0, laneAngles.Count);

        transform.RotateAround(Middle.transform.position, Vector3.down, selectedAngle);
        transform.LookAt(Middle.transform);

        journeyLength = Vector3.Distance(transform.position, Middle.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        //print(timeofdeath);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate () {
        float step = RateOfTravel * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Middle.transform.position, step);
        timeofdeath += Time.deltaTime;
    }
}
