using UnityEngine;
using System.Collections;

public class TriggerSwitch : MonoBehaviour {

	public GameObject Switch;

	void OnTriggerEnter(Collider info){
		if (info.tag == "Player"){
			Switch.GetComponent<ButtonPress>().canSwitch = true;
		}
	}





}
