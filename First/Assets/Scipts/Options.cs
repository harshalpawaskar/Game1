using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject onButton;
    public GameObject offButton;
    public float offColor;

    public void turnOn()
    {
        Color color = onButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        onButton.GetComponent<UnityEngine.UI.Image>().color = color;
        color = offButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = offColor;
        offButton.GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Vibrate", "true");
    }

    public void turnOff()
    {
        Color color = offButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = 1f;
        offButton.GetComponent<UnityEngine.UI.Image>().color = color;
        color = onButton.GetComponent<UnityEngine.UI.Image>().color;
        color.a = offColor;
        onButton.GetComponent<UnityEngine.UI.Image>().color = color;
        PlayerPrefs.SetString("Vibrate", "false");
    }
}
