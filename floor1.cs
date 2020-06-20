using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor1 : MonoBehaviour
{    
    public float move;
     
    void Update()
    {
        move = move + Time.deltaTime;
        if (move < 5)
        { 
        transform.Translate(0, Time.deltaTime, 0); //for making ground layer(Parallax)
        }
        else if (move > 5)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            if(move > 10)
            move = move - 10;
        }
    }
}
