using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //public Rigidbody rb;
    Animator anim;

    public int attack;
    public int defense;
    public int animState;
    public int isPlayer;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(0,1,0) * 300 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * 300 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, -1, 0) * 300 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector3(1, 0, 0) * 300 * Time.deltaTime);
        }*/
    }
    /*
    public void SetAnimState(int newState)
    {
        anim.SetInteger("animState", newState);
    }

    public void SetFight(bool newState)
    {
        anim.SetBool("fight", newState);
    }
    public void SetDefense(bool newState)
    {
        anim.SetBool("defend", newState);
    }
    public void SetDeath(bool newState)
    {
        anim.SetBool("death", newState);
    }
    public void SetIdle(bool newState)
    {
        anim.SetBool("idle", newState);
    }*/

    public void SetFight0()
    {
        anim.SetTrigger("fight 0");
    }
    public void SetDefense0()
    {
        anim.SetTrigger("defend 0");
    }
    public void SetDeath0()
    {
        anim.SetTrigger("death 0");
        isDead = true;
        if(isPlayer == 1)
        {
            isDead = false;
        }
    }
    public void SetIdle0()
    {
        anim.SetTrigger("idle 0");
    }
    public bool IsDead()
    {
        return isDead;
    }
}
