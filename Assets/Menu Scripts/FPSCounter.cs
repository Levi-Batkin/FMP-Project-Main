using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpscounter;
 
    private void Start()
    {
        Debug.Log("Loader > FPSCounter.cs loaded");
    }
 
    private void Update()
    {
        int fps = (int)(1f / Time.unscaledDeltaTime);
        fpscounter.text = "FPS: " + fps;
    }
}
 
