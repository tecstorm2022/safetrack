using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Button loginBtn;
    public InputField email;
    public InputField password;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = loginBtn.GetComponent<Button>();
        btn.onClick.AddListener(loginClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void loginClick(){
        if (email.text == "doctor@mail.com" && password.text == "1234")
        {
            Debug.Log ("sucess");
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
