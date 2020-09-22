using UnityEngine;
using System.Collections;

public class AddTorqueTrigger : MonoBehaviour {

    public Vector3 Torque;
	void OnTriggerStay (Collider info) {

        if (info.tag == "Player")
        {
            info.GetComponent<Rigidbody>().AddTorque(Torque);
        }
	}
}
