using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foor2 : MonoBehaviour
{
    public float move;

    void Start()
    {

    }


    void Update()
    {
        move = move + Time.deltaTime;
        if (move < 2)
        {
            transform.Translate(0, Time.deltaTime, 0);
        }
        else if (move > 2)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            if (move > 4)
                move = move - 4;
        }
    }
}
