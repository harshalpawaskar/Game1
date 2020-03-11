using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject onButton;
    public GameObject offButton;

    public void turnOn()
    {
        Color color = onButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1;
        onButton.GetComponent<UnityEngine.UI.Image>().color = color;
    }


    [System.Obsolete]
    public bool vibrateOnOrOff()
    {
        if (onButton.active)
            return true;
        return false;
    }
}
