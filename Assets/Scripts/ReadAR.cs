using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ReadAR : MonoBehaviour
{
    public TextAsset jsonFile;

    public PulseH pulseH;
    
    private int[]  hr;

    public Text hrText;

    public GameObject alert, warning;

    // Start is called before the first frame update
    void Start()
    {
        
        PValue tempratureJSON = JsonUtility.FromJson<PValue>(jsonFile.text);
        
        hr = tempratureJSON.hr;
        
        StartCoroutine(ReadPValues(hr));
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator ReadPValues(int[] hr)
    {
        for (int i = 0; i < hr.Length; i++)
        {

            hrText.text = hr[i].ToString();
            EvaluateHR(hr[i]);
            
            yield return new WaitForSeconds(3);
        }
    }
    
    void EvaluateHR(int hr)
    {
        if (hr >=50 && hr < 110)
        {
            pulseH.pulsation = 0.035f;
            alert.SetActive(false);
            warning.SetActive(false);
            
        } else if ((hr > 20 && hr < 50))
        {
            pulseH.pulsation = 0.045f;
            alert.SetActive(false);
            warning.SetActive(true);
        } else if ((hr >= 110 && hr < 150))
        {
            pulseH.pulsation = 0.015f;
            alert.SetActive(false);
            warning.SetActive(true);
        } else if (hr <= 20)
        {
            pulseH.pulsation = 0.055f;
            alert.SetActive(true);
            warning.SetActive(false);
        } else if (hr >= 150)
        {
            pulseH.pulsation = 0.005f;
            alert.SetActive(true);
            warning.SetActive(false);
        }
    }

}
