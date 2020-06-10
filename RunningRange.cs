using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRange : MonoBehaviour
{
    public EnemyScript enemyScript;
    //public GameObject attacking;

    void OnTriggerStay2D(Collider2D running)
    {
        if (running.gameObject.tag == "PlayerPos")
        {            
            //enemyScript.Walking = false;
            enemyScript.Running = true;
            Debug.Log("Enemy Running");                        
        }
        else
        {
            //enemyScript.Walking = true;            
            enemyScript.Running = false;            
        }
        
        

        /*else
        {            
            enemyScript.Running = false;
            enemyScript.Walking = true;
            Debug.Log("enemy lost");
        }*/
    }    
}
