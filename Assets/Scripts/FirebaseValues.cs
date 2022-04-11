using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FirebaseValues : MonoBehaviour
{
    public Text alert1, alert2, alert3, alert4, alert5, date1, date2, date3, date4, date5;

    private String alertText;

    public TextAsset jsonFile;
    
    // Start is called before the first frame update
    void Start()
    {
        RestClient.GetArray<string>("https://safetrack-tecstorm-default-rtdb.europe-west1.firebasedatabase.app/P1/Alerts/patient1Alerts.json").Then(allUsers => {
            ReturnData(allUsers);
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReturnData(string[] alertT)
    {

        for (int i = 0; i < alertT.Length; i++)
        {
            String[] bruh = alertT[i].Split('|');
            switch (i)
            {
                case 0:
                    date1.text = bruh[0];
                    alert1.text = bruh[1];
                    break;
                case 1:
                    date2.text = bruh[0];
                    alert2.text = bruh[1];
                    break;
                case 2:
                    date3.text = bruh[0];
                    alert3.text = bruh[1];
                    break;
                case 3:
                    date4.text = bruh[0];
                    alert4.text = bruh[1];
                    break;
                case 4:
                    date5.text = bruh[0];
                    alert5.text = bruh[1];
                    break;
            }
        }
        
    }
    

}
