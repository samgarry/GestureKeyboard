using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sustainPedal : MonoBehaviour
{
    public int sustainCounter;

    public void sustainOn()
    {
        sustainCounter = 1;
    }

    public void sustainOff()
    {
        sustainCounter = 0;
    }
}
