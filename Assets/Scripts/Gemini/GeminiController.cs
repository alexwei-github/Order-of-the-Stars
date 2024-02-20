using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeminiController : MonoBehaviour
{
    public int starCount = 0;

    // Update is called once per frame
    void Update()
    {
        if(starCount == 2){
            SceneManager.LoadScene(1);
        }
    }
}
