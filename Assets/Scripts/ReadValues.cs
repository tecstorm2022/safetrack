using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadValues : MonoBehaviour
{
    public TextAsset jsonFile;

    private int[] temps, spo2, hr, bp;

    public Text tempratureText, spoText, hrText, bpText;
    
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

    IEnumerator ReadPValues(int[] temprature, int[] spo2, int[] hr, int[] bp)
    {
        for (int i = 0; i < temprature.Length; i++)
        {
            tempratureText.text = temprature[i].ToString();
            spoText.text = spo2[i].ToString();
            hrText.text = hr[i].ToString();
            bpText.text = bp[i].ToString();
            
            yield return new WaitForSeconds(5);
        }
    }
}
