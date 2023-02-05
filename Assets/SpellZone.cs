using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpellZone : MonoBehaviour
{

    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerExit;
    Renderer myRenderer;

    bool triggerIsDa = false;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
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
            myRenderer.material.color = new Color(0.01f, 0.01f, 1.0f);
            triggerIsDa = true;
            Debug.Log("Collision");
            onTriggerEnter.Invoke(other);
        }
        // Do stuff
    }

    void OnTriggerExit(Collider other)
    {
        myRenderer.material.color = new Color(1.0f, 0.2f, 0.2f);
        Debug.Log("CollisionTriggerExit");
        if (other.transform.tag == "SpellCard")
        {
            triggerIsDa = false;
            Debug.Log("Collision");
            onTriggerExit.Invoke(other);
        }
        // Do stuff
    }
}
