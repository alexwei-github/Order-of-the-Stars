using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationAppear : MonoBehaviour
{
    public ConstellationChecker checker;
    public SpriteRenderer sprite;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        checker = GameObject.FindGameObjectWithTag("GameController").GetComponent<ConstellationChecker>();
        switch(name){
            case "Cancer": 
                if(checker.Cancer){
                    sprite.enabled = true;
                }
                break;
            case "Pegasus":
                if(checker.Pegasus){
                    sprite.enabled = true;
                }
                break;
            case "Scorpio":
                if(checker.Scorpio){
                    sprite.enabled = true;
                }
                break;
            case "Gemini":
                if(checker.Gemini){
                    sprite.enabled = true;
                }
                break;
            case "Capricorn":
                if(checker.Capricorn){
                    sprite.enabled = true;
                }
                break;
        }
    }
}
