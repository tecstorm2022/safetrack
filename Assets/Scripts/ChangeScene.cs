using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button btn;

    public String scene;
    
    // Start is called before the first frame update
    void Start()
    {
        Button presBtn = btn.GetComponent<Button>();
        presBtn.onClick.AddListener(changeScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
