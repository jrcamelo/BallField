using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour
{

	public GameObject Wall;
	public GameObject Floor;
	public GameObject Light;

	public Material MaterialOff;
	public Material MaterialOn;

	public bool Switch = false;

	public bool canSwitch = true;

	void OnTriggerEnter (Collider info)
	{	
		if (info.tag == "Player" && canSwitch == true) {
			if (Switch == false) {
				Switch = true;
			} else {
				Switch = false;
			}
			canSwitch = false;
		}
	}

	void Update(){
		if (Switch == true) {
			gameObject.GetComponent<MeshRenderer> ().material = MaterialOn;
		} else {
			gameObject.GetComponent<MeshRenderer> ().material = MaterialOff;
		}

        if (Wall)
        {
            Wall.GetComponent<MeshRenderer>().enabled = Switch;
            Wall.GetComponent<BoxCollider>().enabled = Switch;
        }

        if (Floor)
        {
            Floor.GetComponent<MeshRenderer>().enabled = Switch;
            Floor.GetComponent<BoxCollider>().enabled = Switch;
        }
		
        if (Light)
        {
            Light.GetComponent<Light>().enabled = Switch;
        }


	}
}
