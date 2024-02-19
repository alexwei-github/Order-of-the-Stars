using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    private float rotation;

    void Update(){

        rotation += Time.deltaTime * speed;
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
