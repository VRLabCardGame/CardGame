using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Rigidbody rb;

    public int attack;
    public int defense;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
        }
    }

    
}
