using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapmove2 : MonoBehaviour
{
    float move = 6.5f;

    void Start()
    {

    }


    void Update()
    {
        move = move + Time.deltaTime;
        if (move > 6.5f)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            if (move > 9.5)
                move = move - 6f;
        }
        else if (move < 6.5f)
        {
            transform.Translate(0, Time.deltaTime, 0);
           
        }
    }
}
