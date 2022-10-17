using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode()]
public class FightZoneHalf : MonoBehaviour
{

    public object Card;
    public bool isTriggered = false;
    public FightZone fightZone;

    public UnityEvent<Collider> onTriggerEnter;

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
        if (other.transform.tag == "Card")
        {
            Debug.Log("Collision");
            Card = other.transform.name;
            onTriggerEnter.Invoke(other);
        }
             // Do stuff
     }

}
