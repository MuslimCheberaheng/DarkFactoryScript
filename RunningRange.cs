using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRange : MonoBehaviour
{
    public EnemyScript enemyScript;    

    void OnTriggerStay2D(Collider2D running) //running to player if player trigger the boxcollider 
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
    }    
}
