using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public Transform Target;

    public bool CameraZ;
    public int DistanceZ;


    public float Lift;

    public int ShakeForce;
    public int ShakeTimes;


    public void AlterValues(int DistanceZoom)
    {
        this.DistanceZ = DistanceZoom;
    }

    void Update()
    {
        if (CameraZ == false)
        {
            transform.position = Target.position + (new Vector3(0, Lift/2, DistanceZ));
        }

        if (ShakeTimes > 0)
        {
            Shake();
        }
        else
        {
            transform.position = Target.position + (new Vector3(0, Lift, DistanceZ));
        }
    }

    public void ShakeStart(int intensity)
    {
        if (intensity > 0)
        {
            ShakeForce = intensity;
            ShakeTimes = (intensity / 20) + 2;
        }
    }

    public void Shake()
    {
        float shakedirection = ShakeForce * ((ShakeTimes % 2) - 0.5f);

        transform.position = Target.position + (new Vector3(0, Lift + shakedirection/100, DistanceZ));
        ShakeTimes--;
    }
}
