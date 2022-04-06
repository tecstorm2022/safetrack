using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ReadValues : MonoBehaviour
{
    public TextAsset jsonFile;

    private float[] temps;
    private int[] spo2, hr;
    private string[] bp;

    private float tempT;
    private int hrT, bpS, bpD, soT;
    private int cont = 1;

    public Text tempratureText, spoText, hrText, bpText, medT, medH, medB, medS;

    public GameObject tA, tD, hA, hD, bA, bD, sA, sD;
    
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

    IEnumerator ReadPValues(float[] temprature, int[] spo2, int[] hr, string[] bp)
    {
        for (int i = 0; i < temprature.Length; i++)
        {
            tempratureText.text = temprature[i].ToString("0.0");
            EvaluateTemp(temprature[i]);
            tempT += temprature[i];
            MedianTemp(tempT, cont);
            
            spoText.text = spo2[i].ToString();
            EvaluateSPO(spo2[i]);
            soT += spo2[i];
            MedianSPO(soT, cont);
            
            hrText.text = hr[i].ToString();
            EvaluateHR(hr[i]);
            hrT += hr[i];
            MedianHR(hrT, cont);
            
            bpText.text = bp[i];
            EvaluateBP(bp[i]);
            MedianBP(bpS, bpD, cont);

            cont++;
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
            sendAlert("High Temprature " + temp);
        }
        else if (temp >= 40.0)
        {
            tempratureText.color = Color.red;
            tA.SetActive(false);
            tD.SetActive(true);
        }
        
    }

    void EvaluateHR(int hr)
    {
        if (hr >=50 && hr < 110)
        {
            hrText.color = Color.green;
            hA.SetActive(false);
            hD.SetActive(false);
        } else if ((hr > 20 && hr < 50) || (hr >= 110 && hr < 150))
        {
            hrText.color = Color.yellow;
            hA.SetActive(true);
            hD.SetActive(false);
        }
        else if (hr <= 20 || hr >= 150)
        {
            hrText.color = Color.red;
            hA.SetActive(false);
            hD.SetActive(true);
        }
    }

    void EvaluateBP(string bp)
    {
        string[] disSis = bp.Split('/');
        
        int sis = Int32.Parse(disSis[0]);
        bpS += sis;
        
        int dis = Int32.Parse(disSis[1]);
        bpD += dis;
        
        if ((sis < 120 && sis >= 90) && (dis < 80 && dis >= 60))
        {
            bpText.color = Color.green;
            bA.SetActive(false);
            bD.SetActive(false);
        }
        else if ((sis <= 90 && dis <= 60) || (sis >= 130) || (dis >= 80))
        {
            bpText.color = Color.red;
            bA.SetActive(false);
            bD.SetActive(true);
        } else if ((sis <= 90 && dis > 60) || (sis > 90 && dis <= 60) || (sis >= 120 && sis < 130 && dis < 80))
        {
            bpText.color = Color.yellow;
            bA.SetActive(true);
            bD.SetActive(false);
        }
    }

    void EvaluateSPO(int spo)
    {
        if (spo >= 95)
        {
            spoText.color = Color.green;
            sA.SetActive(false);
            sD.SetActive(false);
        } else if (spo == 93 || spo == 94)
        {
            spoText.color = Color.yellow;
            sA.SetActive(true);
            sD.SetActive(false);
        }
        else if (spo <= 92)
        {
            spoText.color = Color.red;
            sA.SetActive(false);
            sD.SetActive(true);
        }
    }

    void MedianTemp(float total, int baseT)
    {
        float med = total / baseT;
        
        medT.text = "Median: " + med.ToString("0.0");;
    }

    void MedianHR(int total, int baseT)
    {
        int med = total / baseT;
        
        medH.text = "Median: " + med;
    }

    void MedianBP(int totalS, int totalD, int baseT)
    {
        int medS = totalS / baseT;
        int medD = totalD / baseT;
        
        medB.text = "Median: " + medS + "/" + medD;
    }

    void MedianSPO(int total, int baseT)
    {
        int med = total / baseT;
        
        medS.text = "Median: " + med;
    }
    
    static string UnixToDate(int Timestamp, string ConvertFormat)
    {
        DateTime ConvertedUnixTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime;
        return ConvertedUnixTime.ToString(ConvertFormat);
    }

    int TimestampMy = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

    void sendAlert(string message)
    {
        
        Alert alert = new Alert(UnixToDate(TimestampMy, "HH:mm:ss"), message);
        RestClient.Post("https://safetrack-tecstorm-default-rtdb.europe-west1.firebasedatabase.app/P1/Alerts.json", alert)
            .Then(
                respose =>
                {
                    Debug.Log(respose);
                });
    }
    
}
