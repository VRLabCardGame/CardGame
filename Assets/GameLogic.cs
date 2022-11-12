using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{


    Dictionary<string, (int attack, int defense)> myDictionary = new Dictionary<string, (int, int)>();

    

    public LifeLineFrontPlayer1 LifePlayer1;
    public LifeLineFrontPlayer1 LifePlayer2;

    public GameObject FieldMarker;

    Card CardPlayer1;
    Card CardPlayer2;

    Vector3 bufferPosition1;
    Vector3 bufferPosition2;

    // Start is called before the first frame update
    void Start()
    {
        myDictionary.Add("Card1", (2, 2));
        myDictionary.Add("Card2", (1, 2));
        myDictionary.Add("fish", (0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateFight(string Card1,  string Card2)
    {
        Debug.Log("Calculating Fight...");
        Debug.Log("Card1: " + Card1);
        Debug.Log("Card2: " + Card2);
        CardPlayer1 = GameObject.Find(Card1).GetComponent<Card>();
        CardPlayer2 = GameObject.Find(Card2).GetComponent<Card>();
        //bufferPosition1 = CardPlayer1.transform.position;
        //bufferPosition2 = CardPlayer2.transform.position;
        //CardPlayer1.transform.position = new Vector3(FieldMarker.transform.position.x, 1+FieldMarker.transform.position.y,
        //    FieldMarker.transform.position.z);
        //CardPlayer1.transform.position = new Vector3(1+FieldMarker.transform.position.x, 1 + FieldMarker.transform.position.y,
        //    FieldMarker.transform.position.z);
        Debug.Log(CardPlayer1.transform.localEulerAngles.z);
        Debug.Log(CardPlayer2.transform.localEulerAngles.z);
        if((CardPlayer1.transform.localEulerAngles.z < 45 || (CardPlayer1.transform.localEulerAngles.z > 135 
            && CardPlayer1.transform.localEulerAngles.z < 225)) &&
            (CardPlayer2.transform.localEulerAngles.z < 45 || (CardPlayer2.transform.localEulerAngles.z > 135
            && CardPlayer2.transform.localEulerAngles.z < 225)))
        {
            Debug.Log("Rotation passt1");
            CardPlayer1.SetAnimState(1);
            CardPlayer2.SetAnimState(2);
            if(myDictionary[Card1].attack > myDictionary[Card2].attack)
            {
                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - (myDictionary[Card1].attack - myDictionary[Card2].attack));
            }
            else
            {
                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - (myDictionary[Card2].attack - myDictionary[Card1].attack));
            }
        }
        else if ((CardPlayer1.transform.localEulerAngles.z < 45 || (CardPlayer1.transform.localEulerAngles.z > 135
            && CardPlayer1.transform.localEulerAngles.z < 225)) &&
            ((CardPlayer2.transform.localEulerAngles.z > 45 && CardPlayer2.transform.localEulerAngles.z < 135)
            || (CardPlayer2.transform.localEulerAngles.z < 315 && CardPlayer2.transform.localEulerAngles.z > 225)))
        {
            Debug.Log("Rotation passt2");
            CardPlayer1.SetAnimState(1);
            CardPlayer2.SetAnimState(2);
            if (myDictionary[Card1].attack > myDictionary[Card2].defense)
            {
                Debug.Log("Destroying Card2");
            }
            else
            {
                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - (myDictionary[Card2].defense - myDictionary[Card1].attack));
            }
        }
        else if ((CardPlayer2.transform.localEulerAngles.z < 45 || (CardPlayer2.transform.localEulerAngles.z > 135
            && CardPlayer2.transform.localEulerAngles.z < 225)) &&
            (CardPlayer1.transform.localEulerAngles.z > 45 && CardPlayer1.transform.localEulerAngles.z < 135
            || (CardPlayer1.transform.localEulerAngles.z < 315 && CardPlayer1.transform.localEulerAngles.z > 225)))
        {
            Debug.Log("Rotation passt3");
            CardPlayer1.SetAnimState(2);
            CardPlayer2.SetAnimState(1);
            if (myDictionary[Card2].attack > myDictionary[Card1].defense)
            {
                Debug.Log("Destroying Card1");
            }
            else
            {
                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - (myDictionary[Card1].defense - myDictionary[Card2].attack));
            }
        }
        else
        {
            Debug.Log("nichts passt :(");
        }
        //CardPlayer1.transform.position = bufferPosition1;
        //CardPlayer2.transform.position = bufferPosition2;





    }

}
