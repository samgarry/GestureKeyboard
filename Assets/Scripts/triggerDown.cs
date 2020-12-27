using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDown : MonoBehaviour
{
    public bool triggerState;

    public void downTrigger()
    {
        triggerState = true;
    }

    public void upTrigger()
    {
        triggerState = false;
    }
}