using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statue : MonoBehaviour
{
    public bool inEvergaol;
    public string nextLevelName;
    public GameObject button;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(inEvergaol == true){
            SceneManager.LoadScene(1);
        }
        else{
            button.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        button.SetActive(false);
    }

    public void OnStatueButton(){
        SceneManager.LoadScene(nextLevelName);
    }
}
