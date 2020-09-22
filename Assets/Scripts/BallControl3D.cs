using UnityEngine;
using System.Collections;

public class BallControl3D : MonoBehaviour
{

    public int rotationSpeed;
    public int jumpHeight;
    private bool isFalling = false;
    int FallTime;
    public float RaycastDistance;
    float RotationX;
    float RotationZ;
    float AirRotationX;
    float AirRotationZ;
    public int MaxAngularVel;
    public ForceMode ForceModeChosen;

    int inputX;
    int inputY;

    void Start()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = MaxAngularVel;
        isFalling = true;
    }

    void Update()
    {    
        RotationX = ((Input.GetAxis("Horizontal") + inputX) * rotationSpeed) * Time.deltaTime / (((FallTime/ 100) / 2) + 1);
        RotationZ = ((Input.GetAxis("Vertical") + inputY) * rotationSpeed) * Time.deltaTime / (((FallTime / 100) / 2) + 1);

        Accelerate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, -Vector3.up, RaycastDistance) || isFalling == false)
            {
                Jump();
            }
        }

        if (isFalling == true || !Physics.Raycast(transform.position, -Vector3.up, RaycastDistance))
        {
            if (FallTime < 200)
            {
                FallTime++;
            }
            AirAccelerate();
        }
        else
        {
            FallTime = 0;
        }


        isFalling = true;
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

    public void JumpButton()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, RaycastDistance) || isFalling == false)
        {
            Jump();
        }
    }

    void Accelerate()
    {
        Vector3 Movement = new Vector3(RotationZ, -RotationX / 2, -RotationX);
        Movement = Camera.main.transform.TransformDirection(Movement);

        GetComponent<Rigidbody>().AddTorque(Movement, ForceModeChosen);

        GetComponent<Rigidbody>().AddForce(new Vector3(0, -10 + (-FallTime), 0));

    }

    public void Jump()
    {
        Vector3 JumpVelocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, GetComponent<Rigidbody>().velocity.z);
        GetComponent<Rigidbody>().velocity = JumpVelocity;
        isFalling = true;   
    }

    void AirAccelerate()
    {
        Vector3 JumpMovement = new Vector3(RotationX, 0, RotationZ);
        JumpMovement = Camera.main.transform.TransformDirection(JumpMovement);
        GetComponent<Rigidbody>().AddForce(JumpMovement);
    }

    void OnCollisionEnter()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, RaycastDistance))
        {
            isFalling = false;
            FallTime = 0;
        }
    }

    void OnCollisionStay()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, RaycastDistance))
        {
            isFalling = false;
            FallTime = 0;
        }
    }
}

