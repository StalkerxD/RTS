using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateHUD : MonoBehaviour {

 
    Text text;


    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
        // Reset the score.
    }
    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "x: " + Input.mousePosition.x + " y: " + Input.mousePosition.y + " z: " + Input.mousePosition.z + " SrollWheel:" + Input.GetAxis("Mouse ScrollWheel");

    }
}
