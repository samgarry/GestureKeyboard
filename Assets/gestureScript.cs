using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class gestureScript : MonoBehaviour
{
    private bool OKHandPose = false;
    //private float speed = 30.0f;  // Speed of our cube
    //private float distance = 2.0f; // Distance between Main Camera and the cube
    private AudioSource sound; // Reference to our Cube
    private MLHandKeyPose[] gestures; // Holds the different hand poses we will look for

    // Start is called before the first frame update
    void Start()
    {
        MLHands.Start(); // Start the hand tracking.

        gestures = new MLHandKeyPose[4]; //Assign the gestures we will look for.
        gestures[0] = MLHandKeyPose.Ok;
        gestures[1] = MLHandKeyPose.Fist;
        gestures[2] = MLHandKeyPose.OpenHand;
        gestures[3] = MLHandKeyPose.Finger;
        // Enable the hand poses.
        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);

        sound = GetComponent<AudioSource>();
        //cube = GameObject.Find("Cube"); // Find our Cube in the scene.
        //cube.SetActive(false);
    }


    private void OnDestroy()
    {
        MLHands.Stop();
    }

    bool GetGesture(MLHand hand, MLHandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.KeyPoseConfidence > 0.9f)
                {
                    return true;
                }
            }
        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {/*
        if (OKHandPose)
        {
            if (GetGesture(MLHands.Left, MLHandKeyPose.OpenHand)
            || GetGesture(MLHands.Right, MLHandKeyPose.OpenHand))
                //cube.transform.Rotate(Vector3.up, +speed * Time.deltaTime);


            if (GetGesture(MLHands.Left, MLHandKeyPose.Fist)
            || GetGesture(MLHands.Right, MLHandKeyPose.Fist))
                //cube.transform.Rotate(Vector3.up, -speed * Time.deltaTime);

        }
        */
    }
}
