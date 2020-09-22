using UnityEngine;
using System.Collections;

public class FloatBall : MonoBehaviour {

    public Vector3 Force;
    public ForceMode f;

    void OnTriggerStay(Collider info)
    {
        if (info.tag == "Player")
        {
            info.GetComponent<Rigidbody>().AddForce(Force, f);
            info.GetComponent<BallControl>().FallTime = 0;
        }
    }
}
