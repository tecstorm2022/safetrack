using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseValues : MonoBehaviour
{
    public Text test;
    // Start is called before the first frame update
    void Start()
    { 
        Debug.Log(UnixToDate(TimestampMy, "HH:mm:ss"));
       ReturnData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReturnData()
    {
        RestClient.Get("https://safetrack-tecstorm-default-rtdb.europe-west1.firebasedatabase.app/Hello.json")
            .Then(
                respose =>
                {
                    Debug.Log(respose.Text);
                    test.text = respose.Text;
                });
    }
    
    static string UnixToDate(int Timestamp, string ConvertFormat)
    {
        DateTime ConvertedUnixTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime;
        return ConvertedUnixTime.ToString(ConvertFormat);
    }

    int TimestampMy = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
}