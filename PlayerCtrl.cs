using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    
    public LinkScene linkingScene;
    Rigidbody2D rb;
    public float speedPlayer;
    public float jumpingHight;
    SpriteRenderer SRflip;
    Animator anim;
    private BoxCollider2D BoxCol;
    [SerializeField] private LayerMask Groundlayermask;            
    public AIEnemy aienemy;
    public DisablePlayer disablePlayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SRflip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        BoxCol = GetComponent<BoxCollider2D>();        
    }   
    
    void Update()
    {
        float Playspeed = Input.GetAxisRaw("Horizontal");
        Playspeed *= speedPlayer;

        if(Playspeed != 0)
        {
            MoveHorizontal(Playspeed);
        }
        else
        {
            Movestop();
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpingHight;
        }            
    }

    public void MoveHorizontal(float Playspeed)
    {
        rb.velocity = new Vector2(Playspeed, rb.velocity.y);
        if(Playspeed < 0)
        {
            SRflip.flipX = true;

            if (Input.GetKey(KeyCode.LeftControl))
            {
                speedPlayer = 3;
                Debug.Log(speedPlayer);
            }
            else
            {
                speedPlayer = 10;
            }
        }
        if(Playspeed > 0)
        {
            SRflip.flipX = false;
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speedPlayer = 3;
                Debug.Log(speedPlayer);
            }
            else
            {
                speedPlayer = 10;
            }
        }
        anim.SetInteger("condition", 1);        
    }

    public void Movestop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetInteger("condition", 0);
    }            
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            StartCoroutine(SetDelay());
            anim.Play("Player_Dead");
            speedPlayer = 0;            
            Debug.Log("Player is dead");            
        }        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("BOX!");
        if (col.gameObject.tag == "box")
        {
            if (Input.GetKey(KeyCode.E))
            {
                //Hiding();
                //disablePlayer.disabled = true;
                Debug.Log("You are hiding");
            }
            else
            {
                //disablePlayer.disabled = false;
                //aienemy.FindingPlayer = true;
            }
        }
    }

    public void PlayerDie()
    {
        anim.SetInteger("condition", 2);        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(BoxCol.bounds.center, BoxCol.bounds.size, 0f, Vector2.down, .1f, Groundlayermask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
    
    IEnumerator SetDelay()
    {        
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene(GoNext + 2);          
        linkingScene.LoadScene("DeadScene");
        Debug.Log("Go Dead Scene");
    }
    /*public void Hiding()
    {
        aienemy.FindingPlayer = false;
        Debug.Log("You are Hiding");
    }*/
}
