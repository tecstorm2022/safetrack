using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Patient1Main : MonoBehaviour
{
    public Button patient1;
    public Button patient2;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btnP1 = patient1.GetComponent<Button>();
        Button btnP2 = patient2.GetComponent<Button>();
        btnP1.onClick.AddListener(EnterPatient1); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterPatient1()
    {
        SceneManager.LoadScene("Scenes/Patient1");
    }
}
