using UnityEngine;
using System.Collections;

public class ButtonPressCForce : MonoBehaviour
{

    public GameObject Light;

    public GameObject OppositeSwitch;
    public GameObject FlyingFloor;
    public int CForce;

    public bool Switch = false;

    void OnTriggerEnter(Collider info)
    {
        if (info.tag == "Player" && Switch == false)
        {
                Switch = true;
                OppositeSwitch.GetComponent<ButtonPressCForce>().Switch = false;
         }
    }

    void Update()
    {
        if (Switch == true)
        {
            FlyingFloor.GetComponent<ConstantForce>().force = new Vector3(0, CForce, 0);
        }

        Light.GetComponent<Light>().enabled = Switch;
        }
}

