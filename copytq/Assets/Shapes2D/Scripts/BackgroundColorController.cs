using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour {

    private Camera cam;
    public Color32 startColor;
    public Color32 endColor;
    public Color32 defaultColor = new Color32(255, 180, 0, 255);
    public float speed = 1.0F;
    private float startTime; 

    void Start() {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        startTime = Time.time;
        startColor = defaultColor;
        endColor = defaultColor;
    }

    void Update() {
        //changes from first color to second color through gradient
        float t = (Time.time - startTime) * speed;
        GetComponent<Camera>().backgroundColor = Color32.Lerp(startColor, endColor, t);
    }

    public void ChangeBackgroundColor(string hexColor) {

        //fetches current color
        startColor = Camera.main.backgroundColor;

        //converting from hexadecimal color value to RGB
        int red, green, blue;
        red = int.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        green = int.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        blue = int.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        endColor = new Color32( (byte) red, (byte) green, (byte) blue, 255);
        
        //reseting start time
        startTime = Time.time;
    }

}

