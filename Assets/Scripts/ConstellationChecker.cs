using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstellationChecker : MonoBehaviour
{
    public static ConstellationChecker Instance;
    
    public GameObject theEnd;

    public bool Pegasus, Cancer, Scorpio, Gemini, Capricorn;


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        if(SceneManager.GetActiveScene().name.Equals("WorldCreate") && Pegasus && Cancer && Scorpio && Gemini && Capricorn){
            theEnd = GameObject.FindGameObjectWithTag("TheEnd");
            theEnd.GetComponent<CircleCollider2D>().enabled = true;
            theEnd.GetComponent<SpriteRenderer>().enabled = true;
        }

        if(!SceneManager.GetActiveScene().name.Equals("WorldCreate")){
            switch(SceneManager.GetActiveScene().name){
            case "Cancer": 
                Cancer = true;
                break;
            case "Pegasus":
                Pegasus = true;
                break;
            case "Scorpio":
                Scorpio = true;
                break;
            case "Gemini":
                Gemini = true;
                break;
            case "Capricorn":
                Capricorn = true;
                break;
        }
        }
    }


}
