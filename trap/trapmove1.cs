using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapmove1 : MonoBehaviour
{
    float move = 3.5f;

    void Start()
    {

    }


    void Update()
    {
        move = move + Time.deltaTime;
        if (move < 8f)
        {
            transform.Translate(0, Time.deltaTime, 0);
        }
        else if (move > 8f)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            if (move >13)
                move = move - 9.5f;
        }
    }
}
