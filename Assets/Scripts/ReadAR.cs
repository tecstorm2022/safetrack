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
    
    
    private int[]  hr;

    public Text hrText;
    

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
            
            yield return new WaitForSeconds(3);
        }
    }
    

}
