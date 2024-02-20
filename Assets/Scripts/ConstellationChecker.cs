using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstellationChecker : MonoBehaviour
{
    public static ConstellationChecker Instance;

    public bool Pegasus, Cancer, Scorpio, Gemini;


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
        if(SceneManager.GetActiveScene().name.Equals("WorldCreate") && Pegasus && Cancer && Scorpio && Gemini){
            SceneManager.LoadScene("TheEnd");
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
        }
        }
    }


}
