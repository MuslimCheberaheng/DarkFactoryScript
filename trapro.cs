﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapro : MonoBehaviour
{
    float speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
