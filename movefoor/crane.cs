using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crane : MonoBehaviour
{
    float move = 5;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.E)) 
        { 
        move = move + Time.deltaTime;
        if (move < 8)
        {
            transform.Translate(0, -Time.deltaTime, 0);
        }
        else if (move == 8)
        {
            transform.Translate(0, 3, 0);

        }
        }
    }
    /*public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
           
            move = move + Time.deltaTime;
            if (move < 8)
            {
                transform.Translate(0, -Time.deltaTime, 0);
            }
            else if (move == 8)
            {
                transform.Translate(0, 3, 0);

            }
        }
    }*/

}
