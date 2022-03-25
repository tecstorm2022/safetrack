using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Image loadCircle;
    
    private float waitTime = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loadCircle.fillAmount += 5.0f / waitTime * Time.deltaTime;

        if (loadCircle.fillAmount == 1)
        {
            SceneManager.LoadScene("Scenes/Main");
        }
    }
}

