using UnityEngine;
using System.Collections;
using System;

public class StartLevel02 : MonoBehaviour {

	// Use this for initialization
    public GameObject Ball;
	void Start () {
        GetComponent<Camera>().fieldOfView = -10;
        

	}


	// Update is called once per frame
	void Update () {
        if (GetComponent<Camera>().fieldOfView < 60)
        {

            Ball.GetComponent<Rigidbody>().AddForce(10, -150, 0);
            Ball.GetComponent<Rigidbody>().AddTorque(0, 0, 150);
            GetComponent<Camera>().fieldOfView++;
        }
	
	}
}
