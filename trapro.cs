using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapro : MonoBehaviour
{
    float speed = 10;   
 
    void Update()
    {
        transform.Rotate(0, 0, speed); //spin the trap(saw trap)
    }
}
