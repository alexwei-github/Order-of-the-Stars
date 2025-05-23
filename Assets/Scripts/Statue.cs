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
        else if(nextLevelName.Equals("Capricorn") && !checker.Capricorn){
            button.SetActive(true);
        }
        else if(nextLevelName.Equals("TheEnd")){
            SceneManager.LoadScene(nextLevelName);
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
