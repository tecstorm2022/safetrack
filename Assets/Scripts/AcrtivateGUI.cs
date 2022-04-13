using System;
using UnityEngine;


public class AcrtivateGUI : MonoBehaviour 
{
    public GameObject heart;
    public GameObject Values;

    private void Update()
    {
        MeshRenderer m = heart.GetComponent<MeshRenderer>();
        if (m.enabled)
        {
            Values.SetActive(true);
        }
        else
        {
            Values.SetActive(false);
        }
    }
}
