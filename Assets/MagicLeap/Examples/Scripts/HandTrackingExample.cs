// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2018-present, Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeapTools;

namespace MagicLeap
{
    /// <summary>
    /// Class outputs to input UI.Text the most up to date gestures
    /// and confidence values for each of the hands.
    /// </summary>
    [RequireComponent(typeof(HandTracking))]

    public class HandTrackingExample : MonoBehaviour
    {
        // Chord Control Elements
        public int counter;
        private triggerDown TD;
        bool triggerState;

        //private string prevHandPoseString = null;
        private bool OKHandPose = false;
        public int timeToDecrease = 10;



        #region Private Variables
        [SerializeField, Tooltip("Text to display gesture status to.")]
        private Text _statusText = null;
        #endregion

        #region Unity Methods
        /// <summary>
        /// Check editor set variables for null references.
        /// </summary>
        void Awake()
        {
            /*
            if (_statusText == null)
            {
                Debug.LogError("Error: HandTrackingExample._statusText is not set, disabling script.");
                enabled = false;
                return;
            }
            */
        }

        // Start is called before the first frame update
        void Start()
        {
            counter = 0;
            /*
            AudioSource[] audios = GetComponents<AudioSource>();

            noteC = audios[0];
            noteC.clip = cNote[0];

            noteCSharp = audios[1];
            noteCSharp.clip = cSharpNote[0];
            noteD = audios[2];
            noteDSharp = audios[3];
            noteE = audios[4];
            noteF = audios[5];
            noteFSharp = audios[6];
            noteG = audios[7];
            noteGSharp = audios[8];
            noteA = audios[9];
            noteASharp = audios[10];
            noteB = audios[11];
            */
            //AudioSource noteC = GetComponent<AudioSource>();
            //AudioSource noteCSharp = GetComponent<AudioSource>();

            /*
            sound = GetComponent<AudioSource>();
            sound.volume = 0.7F;
            sound.pitch = 1.5F;
            print(sound.pitch);
            */
        }


        bool GetGesture(MLHand hand, MLHandKeyPose type)
        {
            if (hand != null)
            {
                if (hand.KeyPose == type)
                {
                    return true;
                    /*if (hand.KeyPoseConfidence > 0.9f)
                    {
                        return true;
                    }*/
                }
            }
            return false;
        }


        /// <summary>
        ///  Polls the Gestures API for up to date confidence values.
        /// </summary>
        void Update()
        {
            TD = GameObject.FindObjectOfType<triggerDown>();
            triggerState = TD.triggerState;

            // In case hand tracking changes before trigger is depressed
            if (triggerState)
                return;

            /*if (MLHands.IsStarted)
            {
                _statusText.text = string.Format(
                    "Current Hand Gestures\nLeft: {0}, {2}% confidence\nRight: {1}, {3}% confidence",
                    MLHands.Left.KeyPose.ToString(),
                    MLHands.Right.KeyPose.ToString(),
                    (MLHands.Left.KeyPoseConfidence * 100.0f).ToString("n0"),
                    (MLHands.Right.KeyPoseConfidence * 100.0f).ToString("n0"));
            
                if (MLHands.Left.KeyPose.ToString() != prevHandPoseString && MLHands.Left.KeyPose.ToString() != null)
                {
                    switch (MLHands.Left.KeyPose.ToString())
                    {

                        case "Ok":
                            print("Handpose = Ok");
                            sound.Play();
                            break;

                        default:
                            break;
                    }
                }
                prevHandPoseString = MLHands.Left.KeyPose.ToString();
            }*/
            if (GetGesture(MLHands.Left, MLHandKeyPose.NoHand))
            {
                counter = 0;
                /*
                noteC.clip = cNote[0];
                noteCSharp.clip = cSharpNote[0];
                noteD.clip = dNote[0];
                noteDSharp.clip = dSharpNote[0];
                noteE.clip = eNote[0];
                noteF.clip = fNote[0];
                noteFSharp.clip = fSharpNote[0];
                noteG.clip = gNote[0];
                noteGSharp.clip = gSharpNote[0];
                noteA.clip = aNote[0];
                noteASharp.clip = aSharpNote[0];
                noteB.clip = bNote[0];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.Finger))
            {
                counter = 1;
                /*
                noteC.clip = cNote[0];
                noteCSharp.clip = cSharpNote[0];
                noteD.clip = dNote[0];
                noteDSharp.clip = dSharpNote[0];
                noteE.clip = eNote[0];
                noteF.clip = fNote[0];
                noteFSharp.clip = fSharpNote[0];
                noteG.clip = gNote[0];
                noteGSharp.clip = gSharpNote[0];
                noteA.clip = aNote[0];
                noteASharp.clip = aSharpNote[0];
                noteB.clip = bNote[0];
                */

            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.L))
            {
                counter = 2;
                /*
                noteC.clip = cNote[1];
                noteCSharp.clip = cSharpNote[1];
                noteD.clip = dNote[1];
                noteDSharp.clip = dSharpNote[1];
                noteE.clip = eNote[1];
                noteF.clip = fNote[1];
                noteFSharp.clip = fSharpNote[1];
                noteG.clip = gNote[1];
                noteGSharp.clip = gSharpNote[1];
                noteA.clip = aNote[1];
                noteASharp.clip = aSharpNote[1];
                noteB.clip = bNote[1];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.Thumb))
            {
                counter = 3;
                /*
                noteC.clip = cNote[2];
                noteCSharp.clip = cSharpNote[2];
                noteD.clip = dNote[2];
                noteDSharp.clip = dSharpNote[2];
                noteE.clip = eNote[2];
                noteF.clip = fNote[2];
                noteFSharp.clip = fSharpNote[2];
                noteG.clip = gNote[2];
                noteGSharp.clip = gSharpNote[2];
                noteA.clip = aNote[2];
                noteASharp.clip = aSharpNote[2];
                noteB.clip = bNote[2];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.C))
            {
                counter = 4;
                /*
                noteC.clip = cNote[3];
                noteCSharp.clip = cSharpNote[3];
                noteD.clip = dNote[3];
                noteDSharp.clip = dSharpNote[3];
                noteE.clip = eNote[3];
                noteF.clip = fNote[3];
                noteFSharp.clip = fSharpNote[3];
                noteG.clip = gNote[3];
                noteGSharp.clip = gSharpNote[3];
                noteA.clip = aNote[3];
                noteASharp.clip = aSharpNote[3];
                noteB.clip = bNote[3];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.Ok))
            {
                counter = 5;
                /*
                noteC.clip = cNote[4];
                noteCSharp.clip = cSharpNote[4];
                noteD.clip = dNote[4];
                noteDSharp.clip = dSharpNote[4];
                noteE.clip = eNote[4];
                noteF.clip = fNote[4];
                noteFSharp.clip = fSharpNote[4];
                noteG.clip = gNote[4];
                noteGSharp.clip = gSharpNote[4];
                noteA.clip = aNote[4];
                noteASharp.clip = aSharpNote[4];
                noteB.clip = bNote[4];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.Pinch))
            {
                counter = 6;
                /*
                noteC.clip = cNote[5];
                noteCSharp.clip = cSharpNote[5];
                noteD.clip = dNote[5];
                noteDSharp.clip = dSharpNote[5];
                noteE.clip = eNote[5];
                noteF.clip = fNote[5];
                noteFSharp.clip = fSharpNote[5];
                noteG.clip = gNote[5];
                noteGSharp.clip = gSharpNote[5];
                noteA.clip = aNote[5];
                noteASharp.clip = aSharpNote[5];
                noteB.clip = bNote[5];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.OpenHand))
            {
                counter = 7;
                /*
                noteC.clip = cNote[6];
                noteCSharp.clip = cSharpNote[6];
                noteD.clip = dNote[6];
                noteDSharp.clip = dSharpNote[6];
                noteE.clip = eNote[6];
                noteF.clip = fNote[6];
                noteFSharp.clip = fSharpNote[6];
                noteG.clip = gNote[6];
                noteGSharp.clip = gSharpNote[6];
                noteA.clip = aNote[6];
                noteASharp.clip = aSharpNote[6];
                noteB.clip = bNote[6];
                */
            }
            if (GetGesture(MLHands.Left, MLHandKeyPose.Fist))
            {
                counter = 8;
                /*
                noteC.clip = cNote[7];
                noteCSharp.clip = cSharpNote[7];
                noteD.clip = dNote[7];
                noteDSharp.clip = dSharpNote[7];
                noteE.clip = eNote[7];
                noteF.clip = fNote[7];
                noteFSharp.clip = fSharpNote[7];
                noteG.clip = gNote[7];
                noteGSharp.clip = gSharpNote[7];
                noteA.clip = aNote[7];
                noteASharp.clip = aSharpNote[7];
                noteB.clip = bNote[7];
                */
            }


        }

    

        /*
        
        public void PlayC()
        {
            GameObject.Find("C").GetComponent<Button>().onClick.Invoke();

            //b.onClick.AddListener(delegate () { noteC.Play(); });

        }
        */
        
        #endregion
    }
}
