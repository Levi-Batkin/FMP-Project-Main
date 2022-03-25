using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugLoader : MonoBehaviour
{
    public TextMeshProUGUI debugtext;
 
    private void Start()
    {
        Debug.Log("Loader > DebugLoader.cs loaded");
        debugtext.text = "Version: v1.0.4 - Skyfall Adventure\nProcessor: "+SystemInfo.processorType+"\nGraphics: "+SystemInfo.graphicsDeviceName+" "+SystemInfo.graphicsDeviceType+"";
    }
 
    private void Update()
    {

    }
}
 
