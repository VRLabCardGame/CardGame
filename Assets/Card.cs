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

    public void SetAnimState(int newState)
    {
        anim.SetInteger("animState", newState);
    }

}
