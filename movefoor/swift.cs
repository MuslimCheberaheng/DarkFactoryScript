using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swift : MonoBehaviour
{
    private Animator anim;
    

     void Start()
    {
        anim = GetComponent<Animator>();
    }

     void Update()
    {
        if ( Input.GetKeyDown("e"))
        {
            anim.SetInteger("LL",1);
        }
    }

    

}
