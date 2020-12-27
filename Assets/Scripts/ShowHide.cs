using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{

    //public GameObject panel;

    GameObject helpPanel = GameObject.Find("Canvas");

    bool state;

    public void SwitchShowHide()
    {
        state = !state;
        helpPanel.gameObject.SetActive(state);
    }
}
