using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPatient : MonoBehaviour
{

    public GameObject patient2;
    public Button addBtn;
    public GameObject addText;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = addBtn.GetComponent<Button>();
        btn.onClick.AddListener(addPatient); 
        addText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void addPatient(){
        patient2.SetActive(true);
        addText.SetActive(true);
    }
}
