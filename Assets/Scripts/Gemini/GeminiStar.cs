using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemini : MonoBehaviour
{
    public GeminiController controller;
    void OnTriggerEnter2D(Collider2D other)
    {
        controller.starCount++;
        Destroy(gameObject);
    }
}
