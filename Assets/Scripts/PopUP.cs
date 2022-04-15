using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUP : MonoBehaviour
{
    public GameObject window;

    public Text message;

    public Button appear, disapear;

    public string messageP = "message";
    
    // Start is called before the first frame update
    void Start()
    {
        Button btnA = appear.GetComponent<Button>();
        btnA.onClick.AddListener(Appear);
        
        Button btnD = disapear.GetComponent<Button>();
        btnD.onClick.AddListener(Dissapear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Appear()
    {
        message.text = messageP;
        window.SetActive(true);
    }

    void Dissapear()
    {
        window.SetActive(false);
    }
}
