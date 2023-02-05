using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class FightZone : MonoBehaviour
{

    public string CardPlayer1 = "";
    public string CardPlayer2 = "";
    public bool isTriggered = false;
    public FightZoneHalf fightZoneHalfPlayer1;
    public FightZoneHalf fightZoneHalfPlayer2;
    public GameLogic gameLogic;

    // Start is called before the first frame update
    void Start()
    {
        CardPlayer1 = "";
        CardPlayer2 = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        fightZoneHalfPlayer1.onTriggerEnter.AddListener(OnTheOtherTriggerEnterMethod);
        fightZoneHalfPlayer2.onTriggerEnter.AddListener(OnTheOtherTriggerEnterMethod1);
        fightZoneHalfPlayer1.onTriggerExit.AddListener(OnTheOtherTriggerExitMethod);
        fightZoneHalfPlayer2.onTriggerExit.AddListener(OnTheOtherTriggerExitMethod1);

    }

    void OnDisable()
    {
        fightZoneHalfPlayer1.onTriggerEnter.RemoveListener(OnTheOtherTriggerEnterMethod);
        fightZoneHalfPlayer2.onTriggerEnter.RemoveListener(OnTheOtherTriggerEnterMethod1);
        fightZoneHalfPlayer1.onTriggerExit.RemoveListener(OnTheOtherTriggerExitMethod);
        fightZoneHalfPlayer2.onTriggerExit.RemoveListener(OnTheOtherTriggerExitMethod1);

    }

    void OnTheOtherTriggerEnterMethod(Collider other)
    {
        Debug.Log("Collisionother1");
        if (other.transform.tag == "Card")
        {
            Debug.Log("Collisionohter");
            CardPlayer1 = other.transform.name;
            if(CardPlayer2 != "")
            {
                gameLogic.CalculateFight(CardPlayer1, CardPlayer2);
                CardPlayer1 = "";
                CardPlayer2 = "";
            }

        }
             // Do stuff
     }

    void OnTheOtherTriggerEnterMethod1(Collider other)
    {
        Debug.Log("Collisionother2");
        if (other.transform.tag == "Card")
        {
            Debug.Log("Collisionohter2");
            CardPlayer2 = other.transform.name;
            if (CardPlayer1 != "")
            {
                gameLogic.CalculateFight(CardPlayer1, CardPlayer2);
                CardPlayer1 = "";
                CardPlayer2 = "";
            }

        }
        // Do stuff
    }

    void OnTheOtherTriggerExitMethod(Collider other)
    {
        Debug.Log("Collisionother2Exit");
        if (other.transform.tag == "Card")
        {
            Debug.Log("Collisionohter2Exit");
            CardPlayer1 = "";
        }
        // Do stuff
    }

    void OnTheOtherTriggerExitMethod1(Collider other)
    {
        Debug.Log("Collisionother2Exit");
        if (other.transform.tag == "Card")
        {
            Debug.Log("Collisionohter2Exit");
            CardPlayer2 = "";
        }
        // Do stuff
    }
}
