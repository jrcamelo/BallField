using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour
{
    public GameObject Camera;
    public AudioClip ThudSFX;
    public int rotationSpeed;
    public int jumpHeight;
    public int dashSpeed;
    public int defaultDashVertical;
    public int dashInterval;
    public int LastDash;
    public bool isFalling = false;
    //public bool DashDown;
    public bool Dashed;
    public int CoyoteTolerance;
    public int CoyoteTime;
    public int CurrentCoyoteTime;
    public int JumpMemory;
    public int CurrentJumpMemory;

    public int FallTime;

    public float RaycastDistance;
    public float RaycastDistanceTolerable;

    public int inputX;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            if (FallTime > 0 )
            {
                if (FallTime < CoyoteTolerance)
                    CurrentCoyoteTime = CoyoteTime;
                else
                    CurrentJumpMemory = JumpMemory;
            }            

            Jump();
        }
        else if (CurrentJumpMemory > 0 || CurrentCoyoteTime > 0)
        {
            Jump();
            CurrentJumpMemory -= 1;
            CurrentCoyoteTime -= 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.X))
        {
            Dash();
        }

        float rotation = (Input.GetAxis("Horizontal") + inputX) * rotationSpeed;
        rotation *= Time.deltaTime / 2;

        GetComponent<Rigidbody>().AddTorque(Vector3.back * rotation);
        GetComponent<Rigidbody>().AddForce(new Vector3((Input.GetAxis("Horizontal") + inputX / 5) * (2 - (FallTime / 49)), 0, 0));

        if (isFalling)
            GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") / 2, (-FallTime / 4) - 1, 0));
        isFalling = true;
    }

    public void FixedUpdate()
    {
        if (LastDash < dashInterval)
            LastDash++;

        if (isFalling == true)
        {
            if (FallTime < 100)
                FallTime++;
        }
        else
        {
            FallTime = 0;
        }
    }

    public void Jump()
    {
        CheckTouchedGround();
        if ((isFalling == false && Physics.Raycast(transform.position, -Vector3.up, RaycastDistance)) || CurrentCoyoteTime > 0)
        {
                GetComponent<Rigidbody>().velocity = new Vector3((GetComponent<Rigidbody>().velocity.x) + Input.GetAxis("Horizontal") + (inputX/5), jumpHeight, 0);
                CurrentCoyoteTime = 0;
                CurrentJumpMemory = 0;           
        }
        else
        {

            // Dash Down
            //if (FallTime > 20 && !DashDown)
            //{
            //    DashDown = true;
            //    Dashed = true;

            //    float velY = GetComponent<Rigidbody>().velocity.y;
            //    if (velY < 0)
            //        velY = 0;
            //    if (velY > jumpHeight)
            //        velY = jumpHeight;
            //    GetComponent<Rigidbody>().velocity = new Vector3(0, velY - jumpHeight * 2, 0);
            //    FallTime = 0;
            //}
        }
    }

    public void Dash()
    {
        CheckTouchedGround();
        if (!Dashed)
        {
            if ((isFalling && FallTime > 0) || LastDash == dashInterval)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(
                    (Input.GetAxis("Horizontal") + (inputX / 5)) * dashSpeed, 
                    GetComponent<Rigidbody>().velocity.y + defaultDashVertical, 
                    0);
                Dashed = true;
                LastDash = 0;
            }
        }
    }

    public void CheckTouchedGround()
    {
        if (isFalling)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, RaycastDistanceTolerable))
            {
                float vol = FallTime / 250f;
                //if (DashDown)
                //{
                //    Camera.GetComponent<CameraControl>().ShakeStart(FallTime);
                //    vol = FallTime / 25f;
                //}
                GetComponent<AudioSource>().PlayOneShot(ThudSFX, vol);

                Dashed = false;
                //DashDown = false;
                isFalling = false;
                FallTime = 0;
            }
        }        
    }

    public void LeftButtonDown() { inputX = -5; }
    public void LeftButtonUp() { inputX = 0; }
    public void RightButtonDown() { inputX = 5; }
    public void RightButtonUp() { inputX = 0; }

    void OnCollisionEnter() { CheckTouchedGround(); }
    void OnCollisionStay() { CheckTouchedGround(); }
}

