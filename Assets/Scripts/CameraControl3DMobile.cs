using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraControl3DMobile : MonoBehaviour
{

    public Transform target;
    public float distance;
    public float xSpeed;
    public float ySpeed;

    public float yMinLimit;
    public float yMaxLimit;

    private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    public int inputX;
    public int inputY;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    public void AlterValues(float Distance)
    {
        this.distance = Distance;
    }

    void LateUpdate()
    {
        if (target)
        {
            x += inputX * xSpeed * distance * 0.02f;
            y -= inputY * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;

        }
    }

    public void LeftButtonDown()
    {
        inputX = -5;
    }

    public void LeftButtonUp()
    {
        inputX = 0;
    }

    public void RightButtonDown()
    {
        inputX = 5;
    }

    public void RightButtonUp()
    {
        inputX = 0;
    }

    public void DownButtonDown()
    {
        inputY = -5;
    }

    public void DownButtonUp()
    {
        inputY = 0;
    }

    public void UpButtonDown()
    {
        inputY = 5;
    }

    public void UpButtonUp()
    {
        inputY = 0;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}