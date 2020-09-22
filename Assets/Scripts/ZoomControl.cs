using UnityEngine;
using System.Collections;

public class ZoomControl : MonoBehaviour
{

    public int DistanceZ;
    public int DistanceZMAX;
    public int DistanceZMIN;

    public float Lift;
    float LiftX;

    void Start()
    {


        //DistanceZ = PlayerPrefs.GetInt("DistanceZ");

        if (DistanceZ > DistanceZMIN)
        {
            DistanceZ = DistanceZMIN - ((DistanceZMAX - DistanceZMIN) / 2);
        }

        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().AlterValues(DistanceZ);
    }

    void Update()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().AlterValues(DistanceZ);
    }

    void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (DistanceZ < DistanceZMIN)
            {
                DistanceZ++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (DistanceZ > DistanceZMAX)
            {
                DistanceZ--;
            }
        }
    }
}
