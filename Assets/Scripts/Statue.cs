using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statue : MonoBehaviour
{
    public bool inEvergaol;
    public string nextLevelName;
    public GameObject button;

    public ConstellationChecker checker;

    void Start(){
        checker = GameObject.FindGameObjectWithTag("GameController").GetComponent<ConstellationChecker>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(inEvergaol == true){
            SceneManager.LoadScene(1);
        }
        else if(nextLevelName.Equals("Cancer") && !checker.Cancer){
            button.SetActive(true);
        }
        else if(nextLevelName.Equals("Pegasus") && !checker.Pegasus){
            button.SetActive(true);
        }
        else if(nextLevelName.Equals("Scorpio") && !checker.Scorpio){
            button.SetActive(true);
        }
        else if(nextLevelName.Equals("Gemini") && !checker.Gemini){
            button.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        button.SetActive(false);
    }

    public void OnStatueButton(){
        SceneManager.LoadScene(nextLevelName);
        switch(nextLevelName){
            case "Cancer": 
                checker.Cancer = true;
                break;
            case "Pegasus":
                checker.Pegasus = true;
                break;
            case "Scorpio":
                checker.Scorpio = true;
                break;
            case "Gemini":
                checker.Gemini = true;
                break;
        }
    }
}
