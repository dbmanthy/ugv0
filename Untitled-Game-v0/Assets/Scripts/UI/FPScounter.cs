
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPScounter : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string displayString = "{0} FPS";
    public Text displayText;

    void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        displayText.text = string.Format(displayString, avgFramerate.ToString());
    }
}
