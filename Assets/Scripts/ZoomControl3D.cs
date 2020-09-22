using UnityEngine;
using System.Collections;

public class ZoomControl3D : MonoBehaviour {

    public float Distance;

    public float DistanceMIN;
    public float DistanceMAX;

    public float ZoomSpeed;
	void Start () {

        //DistanceZ = PlayerPrefs.GetInt("DistanceZ");

        if (Distance > DistanceMIN)
        {
            Distance = DistanceMIN - ((DistanceMAX - DistanceMIN) / 2);
        }

        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl3D>().AlterValues(Distance);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus))
        {
            Distance -= ZoomSpeed;
        }

        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            Distance += ZoomSpeed;
        }

        Distance = Mathf.Clamp(Distance - Input.GetAxis("Mouse ScrollWheel") * 5, DistanceMIN, DistanceMAX);

 

        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl3D>().AlterValues(Distance);
	}
}
