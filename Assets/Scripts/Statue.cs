using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statue : MonoBehaviour
{
    public bool inEvergaol;
    public string nextLevelName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(inEvergaol == true){
            SceneManager.LoadScene(0);
        }
        else{
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
