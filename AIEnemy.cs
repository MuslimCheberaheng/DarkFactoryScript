using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] float CloseDistance; //create the range of collider 
    [SerializeField] float MidDistance;
    [SerializeField] float LongDistance;
    [SerializeField] Transform player;
    public bool BackToPos = false; 
    public float DistanceToPlayer = Mathf.Infinity;
    public float DistanceToBack = Mathf.Infinity;
    Animator animate;
    public float NPC_speed;
    bool FindingPlayer = false;
    public PlayerCtrl2 playerCTRL2;
    [SerializeField] Transform EnemyPlace;//Enemy position

    void Awake()
    {
        animate = GetComponent<Animator>();
    }
    
    void Update()
    {
        DetectPlayer();        

        if(BackToPos == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyPlace.position, NPC_speed * Time.deltaTime);
            
        }
    }

    public void DetectPlayer()
    {
        DistanceToPlayer = Vector3.Distance(player.position, transform.position); //Enemy move to player 
        DistanceToBack = Vector3.Distance(EnemyPlace.position, transform.position);
        if (DistanceToPlayer <= LongDistance) //if player is not inside Longdistance
        {
            NPC_speed = 0;
            if (DistanceToPlayer <= MidDistance && playerCTRL2.disablePLAYER.disabled == false)
            {
                animate.SetInteger("EnemyCondition", 1);
                Debug.Log("Enemy Walking");
                NPC_speed = 5;                                
                transform.position = Vector2.MoveTowards(transform.position, player.position, NPC_speed * Time.deltaTime);                                                                                                            
                
                if (DistanceToPlayer < CloseDistance && playerCTRL2.disablePLAYER.disabled == true)
                {
                    BackToPos = true;                                                                    
                }
                else if(DistanceToPlayer < CloseDistance && playerCTRL2.disablePLAYER.disabled == false)
                {
                    NPC_speed = 0;
                    animate.SetInteger("EnemyCondition", 2);
                    Debug.Log("Enemy Attacking");
                }
            }
            else if(playerCTRL2.disablePLAYER.disabled == true)
            {
                BackToPos = true;
            }            
        }
        else
        {
            animate.SetInteger("EnemyCondition", 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, CloseDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MidDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LongDistance);
    }    
}
