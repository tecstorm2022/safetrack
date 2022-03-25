using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject loginBtn;
    public InputField email;
    public InputField password;
    public GameObject loading;
    public GameObject fail;
    
    
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
        fail.SetActive(false);
        if (email.text == "doctor@mail.com" && password.text == "1234")
        {
            loginBtn.SetActive(false);
            loading.SetActive(true);
        }
        else
        {
            fail.SetActive(true);
        }
    }
}
