using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
    
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
            var img = GetComponent<Image>();
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Scenes/Login");
    }
}
