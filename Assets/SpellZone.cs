using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpellZone : MonoBehaviour
{

    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerExit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision1");
        if (other.transform.tag == "SpellCard")
        {
            Debug.Log("Collision");
            onTriggerEnter.Invoke(other);
        }
        // Do stuff
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision1");
        if (other.transform.tag == "SpellCard")
        {
            Debug.Log("Collision");
            onTriggerExit.Invoke(other);
        }
        // Do stuff
    }
}
