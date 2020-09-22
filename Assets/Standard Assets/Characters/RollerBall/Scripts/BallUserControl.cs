using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.

        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.

        public Transform cam; // A reference to the main camera in the scenes transform
        private Vector3 camForward; // The current forward direction of the camera

        public int jumpHeight;

        public float RaycastDistance;
        private bool isFalling;
        private int FallTime;


        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();


            // get the transform of the main camera
            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
            }
        }


        private void Update()
        {
            // Get the axis and jump input.

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            GetComponent<Rigidbody>().AddForce(new Vector3(h * (10 - (FallTime / 20)), 0, v * (10 - (FallTime / 20))));


            // calculate move direction
            if (cam != null)
            {
                // calculate camera relative direction to move:
                //camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (v * camForward + h * cam.right).normalized;
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics.Raycast(transform.position, -Vector3.up, RaycastDistance) || isFalling == false)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3((GetComponent<Rigidbody>().velocity.x), jumpHeight, GetComponent<Rigidbody>().velocity.z);
                }
            }

            if (isFalling == true)
            {

                if (FallTime < 100)
                {
                    FallTime++;
                }
                GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * 2, -FallTime / 20, 0));
            }
            else
            {
                FallTime = 0;
            }

            isFalling = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel("Level02");
            }
        }


        void OnCollisionEnter()
        {
            isFalling = false;
            FallTime = 0;
        }

        void OnCollisionStay()
        {
            isFalling = false;
            FallTime = 0;
        }

        void OnTriggerEnter()
        {
            isFalling = false;
        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            bool jump = false;
            ball.Move(move, jump);
        }
    }
}
