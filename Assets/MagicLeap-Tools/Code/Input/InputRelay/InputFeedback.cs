// ---------------------------------------------------------------------
//
// Copyright (c) 2019 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// ---------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System;
using MagicLeap;
using UnityEngine;
using UnityEngine.UI;

namespace MagicLeapTools
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(InputReceiver))]
    public class InputFeedback : MonoBehaviour
    {
#if PLATFORM_LUMIN
        //Public Variables:
        public Renderer targetRenderer;
        public Color targetedColor = Color.gray;
        public Color selectedColor = Color.green;
        public Color draggedColor = Color.magenta;

        // Sound Audio Clips
        public AudioClip[] sound;
        float volume = 2.0F;

        // Chord Highlight Features
        public GameObject[] currentChord;

        public GameObject[] majorTriad;
        public GameObject[] majorSeventh;
        public GameObject[] dominantSeventh;
        public GameObject[] minorSeventh;
        public GameObject[] halfDiminished;
        public GameObject[] diminished;
        public GameObject[] sus4;
        public GameObject[] minorTriad;

        public Material selectedMaterial;
        public Material deselectedMaterialWhite;
        public Material deselectedMaterialBlack;

        // Text Elements
        //public Text textDisplay = GameObject.Find("TextObject").GetComponent<Text>();
        public Text textDisplay;

        // Chord Control Elements
        private HandTrackingExample HTE;
        int counter;
        private sustainPedal SP;
        int sustainCounter;

        // Octave Control Elements
        private touchpadInput TI;
        int touchpadCounter;

        private triggerDown TD;

        //public bool selected;

        /*
        public AudioClip targetBeginSound;
        public AudioClip targetEndSound;
        public AudioClip selectedSound;
        public AudioClip deselectedSound;
        public AudioClip dragStartSound;
        public AudioClip dragStopSound;
        public AudioClip collisionSound;
        */



        //Private Variables:
        private InputReceiver _inputReceiver;
        private AudioSource _audioSource;
        private Color _idleColor;

        //Init:
        private void Reset()
        {
            //refs:
            targetRenderer = GetComponent<Renderer>();
        }

        private void Awake()
        {
            //refs:
            _audioSource = GetComponent<AudioSource>();
            _inputReceiver = GetComponent<InputReceiver>();

            //sets:
            if (targetRenderer != null)
            {
                _idleColor = targetRenderer.material.color;
            }

            //Text:
            textDisplay = GameObject.Find("TextObject").GetComponent<Text>();
            textDisplay.text = "";
        }


        // Update is called once per frame
        public void Update()
        {
            //Text Updater
            //string audioText = _audioSource.clip.ToString();
            //textDisplay = GameObject.Find("TextObject").GetComponent<Text>();
            //textDisplay.text = audioText;

            // File & Counter Management
            TD = FindObjectOfType<triggerDown>();

            HTE = GameObject.FindObjectOfType<HandTrackingExample>();
            counter = HTE.counter;

            SP = GameObject.FindObjectOfType<sustainPedal>();
            sustainCounter = SP.sustainCounter;

            TI = GameObject.FindObjectOfType<touchpadInput>();
            touchpadCounter = TI.touchpadCounter;

            // NO HAND --- NOTE
            if (counter == 0)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[0];
                else
                    _audioSource.clip = sound[9];

                if (currentChord[0] != null)
                {
                    Array.Clear(currentChord, 0, currentChord.Length);
                }
            }

            // Finger --- Sus4
            if (counter == 1)
            {
                if(touchpadCounter == 0)
                    _audioSource.clip = sound[1];
                else
                    _audioSource.clip = sound[10];

                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = sus4[i];
                }
            }

            // L --- MINOR TRIAD
            if (counter == 2)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[2];
                else
                    _audioSource.clip = sound[11];

                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = minorTriad[i];
                }
            }

            // THUMB --- MAJOR TRIAD
            if (counter == 3)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[3];
                else
                    _audioSource.clip = sound[12];

                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = majorTriad[i];
                }
            }


            // C --- MAJOR SEVENTH
            if (counter == 4)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[4];
                else
                    _audioSource.clip = sound[13];

                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = majorSeventh[i];
                }
            }

            // OK --- DOMINANT SEVENTH
            if (counter == 5)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[5];
                else
                    _audioSource.clip = sound[14];

                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = dominantSeventh[i];
                }
            }

            // PINCH --- MINOR SEVENTH
            if (counter == 6)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[6];
                else
                    _audioSource.clip = sound[15];

                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = minorSeventh[i];
                }
            }

            // HAND --- HALF DIMINISHED
            if (counter == 7)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[7];
                else
                    _audioSource.clip = sound[16];
                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = halfDiminished[i];
                }
            }

            // FIST --- DIMINISHED
            if (counter == 8)
            {
                if (touchpadCounter == 0)
                    _audioSource.clip = sound[8];
                else
                    _audioSource.clip = sound[17];
                for (int i = 0; i < 3; i++)
                {
                    currentChord[i] = diminished[i];
                }
            }
        }


    //Flow:
    private void OnEnable()
        {
            //hooks:
            _inputReceiver.OnTargetEnter.AddListener(HandleTargetEnter);
            _inputReceiver.OnTargetExit.AddListener(HandleTargetExit);
            _inputReceiver.OnSelected.AddListener(HandleSelect);
            _inputReceiver.OnDeselected.AddListener(HandleDeselect);
            _inputReceiver.OnDragBegin.AddListener(HandleDragBegin);
            _inputReceiver.OnDragEnd.AddListener(HandleDragEnd);

            //pointer collision events:
            PointerReceiver pointerReceiver = GetComponent<PointerReceiver>();
            if (pointerReceiver != null)
            {
                pointerReceiver.OnDraggedCollisionEnter.AddListener(HandleDraggedCollision);
            }
        }

        private void OnDisable()
        {
            //unhooks:
            _inputReceiver.OnTargetEnter.RemoveListener(HandleTargetEnter);
            _inputReceiver.OnTargetExit.RemoveListener(HandleTargetExit);
            _inputReceiver.OnSelected.RemoveListener(HandleSelect);
            _inputReceiver.OnDeselected.RemoveListener(HandleDeselect);
            _inputReceiver.OnDragBegin.RemoveListener(HandleDragBegin);
            _inputReceiver.OnDragEnd.RemoveListener(HandleDragEnd);

            //pointer collision events:
            PointerReceiver pointerReceiver = GetComponent<PointerReceiver>();
            if (pointerReceiver != null)
            {
                pointerReceiver.OnDraggedCollisionEnter.RemoveListener(HandleDraggedCollision);
            }
        }

        //Event Handlers
        private void HandleDraggedCollision(Collision collision, GameObject sender)
        {
            /*
            if (collisionSound != null)
            {
                float force = Mathf.Clamp(collision.impulse.magnitude, .1f, 1);
                //_audioSource.PlayOneShot(collisionSound, force);
            }
            */
        }

        private void HandleTargetEnter(GameObject sender)
        {
            if (_inputReceiver.TargetedBy.Count != 1)
            {
                return;
            }

            if (targetRenderer != null)
            {
                targetRenderer.material.color = targetedColor;
            }
            /*
            if (targetBeginSound != null)
            {
                //_audioSource.PlayOneShot(targetBeginSound);
            }
            */
        }

        private void HandleTargetExit(GameObject sender)
        {
            if (_inputReceiver.TargetedBy.Count != 0)
            {
                return;
            }

            if (targetRenderer != null)
            {
                targetRenderer.material.color = _idleColor;
            }
            /*
            if (targetEndSound != null)
            {
                //_audioSource.PlayOneShot(targetEndSound);
            }
            */
        }

        private void HandleSelect(GameObject sender)
        {
            if (_inputReceiver.SelectedBy.Count != 1)
            {
                return;
            }

            TD.downTrigger();

            //Text Handle
            string audioText = _audioSource.clip.name;
            //textDisplay = GameObject.Find("TextObject").GetComponent<Text>();
            textDisplay = FindObjectOfType<Text>();
            textDisplay.text = audioText;

            if (targetRenderer != null)
            {
                targetRenderer.material.color = selectedColor;
                if (currentChord[0] != null)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        if (currentChord[i] != null)
                            currentChord[i].GetComponent<MeshRenderer>().material = selectedMaterial;
                    }
                }
                _audioSource.PlayOneShot(_audioSource.clip, volume);
            }
            /*
            if (selectedSound != null)
            {
                _audioSource.Play();
            }
            */
        }

        private void HandleDeselect(GameObject sender)
        {
            if (_inputReceiver.SelectedBy.Count != 0)
            {
                return;
            }

            TD.upTrigger();

            //Text Handle
            textDisplay = GameObject.Find("TextObject").GetComponent<Text>();
            textDisplay.text = "";

            if (targetRenderer != null)
            {
                targetRenderer.material.color = targetedColor;
                if (currentChord[0] != null)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        if (currentChord[i] != null)
                        {
                            if (currentChord[i].name != "C#" && currentChord[i].name != "D#" && currentChord[i].name != "F#"
                                && currentChord[i].name != "G#" && currentChord[i].name != "A#")
                            {
                                currentChord[i].GetComponent<MeshRenderer>().material = deselectedMaterialWhite;
                            }
                            else
                                currentChord[i].GetComponent<MeshRenderer>().material = deselectedMaterialBlack;
                        }
                    }
                }
                Array.Clear(currentChord, 0, currentChord.Length);
                if (sustainCounter == 0)
                {
                    _audioSource.Stop();
                }
            }
            /*
            if (deselectedSound != null)
            {
                //_audioSource.Stop();
            }
            */
        }

        private void HandleDragBegin(GameObject sender)
        {
            if (_inputReceiver.DraggedBy.Count != 1)
            {
                return;
            }

            if (targetRenderer != null)
            {
                targetRenderer.material.color = selectedColor;
            }
            /*
            if (dragStartSound != null)
            {
                //_audioSource.PlayOneShot(dragStartSound);
            }
            */
        }

        private void HandleDragEnd(GameObject sender)
        {
            if (_inputReceiver.DraggedBy.Count > 0)
            {
                return;
            }

            if (targetRenderer != null)
            {
                targetRenderer.material.color = selectedColor;
            }
            /*
            if (dragStopSound != null)
            {
                //_audioSource.PlayOneShot(dragStopSound);
            }
            */
        }
#endif
    }
}