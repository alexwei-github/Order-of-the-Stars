using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    float timePassed = 0f;
    public ConstellationChecker checker;

    void Start(){
        checker = GameObject.FindGameObjectWithTag("GameController").GetComponent<ConstellationChecker>();
        checker.Cancer = false;
        checker.Gemini = false;
        checker.Pegasus = false;
        checker.Scorpio = false;
        checker.Capricorn = false;
    }
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed > 5f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
