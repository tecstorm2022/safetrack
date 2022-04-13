using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    // Assign in the inspector
    public GameObject objectToRotate;
    public Slider slider;
    public int rotateType;
 
    // Preserve the original and current orientation
    private float previousValue;
 
    void Awake ()
    {
        // Assign a callback for when this slider changes
        this.slider.onValueChanged.AddListener (this.OnSliderChanged);
 
        // And current value
        this.previousValue = this.slider.value;
    }
 
    void OnSliderChanged (float value)
    {
        // How much we've changed
        float delta = value - this.previousValue;
        if (rotateType == 0)
        {
            this.objectToRotate.transform.Rotate (Vector3.right * delta * 360);
        }
        else
        {
            this.objectToRotate.transform.Rotate (Vector3.forward * delta * 360);
        }

        // Set our previous value for the next change
        this.previousValue = value;
    }
}
