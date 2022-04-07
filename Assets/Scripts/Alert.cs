using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Alert
{
   public string time;
   public string msg;

   public Alert(string aTime, string aMsg)
   {
      time = aTime;
      msg = aMsg;
   }
   
}
