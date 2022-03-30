using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadValues : MonoBehaviour
{
    public TextAsset jsonFile;

    private float[] temps;
    private int[] spo2, hr, bp;

    public Text tempratureText, spoText, hrText, bpText;

    public GameObject tA, tD;
    
    // Start is called before the first frame update
    void Start()
    {
        PValue tempratureJSON = JsonUtility.FromJson<PValue>(jsonFile.text);

        temps = tempratureJSON.temp;
        spo2 = tempratureJSON.spo2;
        hr = tempratureJSON.hr;
        bp = tempratureJSON.bp;

        StartCoroutine(ReadPValues(temps, spo2, hr, bp));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReadPValues(float[] temprature, int[] spo2, int[] hr, int[] bp)
    {
        for (int i = 0; i < temprature.Length; i++)
        {
            tempratureText.text = temprature[i].ToString("0.0");
            EvaluateTemp(temprature[i]);
            spoText.text = spo2[i].ToString();
            hrText.text = hr[i].ToString();
            bpText.text = bp[i].ToString();
            
            yield return new WaitForSeconds(3);
        }
    }

    void EvaluateTemp(float temp)
    {
        if (temp < 37.0)
        {
            tempratureText.color = Color.green;
            tA.SetActive(false);
            tD.SetActive(false);
        } else if (temp >= 37.0 && temp < 40.0)
        {
            tempratureText.color = Color.yellow;
            tA.SetActive(true);
            tD.SetActive(false);
        }
        else if (temp >= 40.0)
        {
            tempratureText.color = Color.red;
            tA.SetActive(false);
            tD.SetActive(true);
        }
    }
}
