using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    // Elements: Blitz: 0, Wasser: 1, Feuer: 2, Pflanze: 3
    Dictionary<string, (int attack, int defense, int element)> myDictionary = new Dictionary<string, (int, int,int)>();

    

    public LifeLineFrontPlayer1 LifePlayer1;
    public LifeLineFrontPlayer1 LifePlayer2;

    public GameObject FieldMarker;

    Card CardPlayer1;
    Card CardPlayer2;

    List<int> modifications;

    int CardPlayer1ValueCalc;
    int CardPlayer2ValueCalc;

    Vector3 bufferPosition1;
    Vector3 bufferPosition2;

    public GameObject particles1;

    

    // Start is called before the first frame update
    void Start()
    {
        myDictionary.Add("Card1", (2, 2, 0));
        myDictionary.Add("Card2", (1, 2, 0));
        myDictionary.Add("fish", (0, 3, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> UseElements(string Card1, string Card2)
    {
        int modificationCard1 = 0;
        int modificationCard2 = 0;
        if(myDictionary[Card1].element - myDictionary[Card2].element == -1 || myDictionary[Card1].element - myDictionary[Card2].element == 3)
        {
            modificationCard1 = 2;
        }
        else if(myDictionary[Card1].element - myDictionary[Card2].element == 1 || myDictionary[Card1].element - myDictionary[Card2].element == -3)
        {
            modificationCard2 = 2;
        }
        List<int> modifs = new List<int>();
        modifs.Add(modificationCard1);
        modifs.Add(modificationCard2);
        return modifs;
    }

    public void CalculateFight(string Card1,  string Card2)
    {
        Debug.Log("Calculating Fight...");
        Debug.Log("Card1: " + Card1);
        Debug.Log("Card2: " + Card2);
        CardPlayer1 = GameObject.Find(Card1).GetComponent<Card>();
        CardPlayer2 = GameObject.Find(Card2).GetComponent<Card>();
        modifications = UseElements(Card1, Card2);
        Debug.Log(CardPlayer1.transform.localEulerAngles.z);
        Debug.Log(CardPlayer2.transform.localEulerAngles.z);
        if((CardPlayer1.transform.localEulerAngles.z < 45 || (CardPlayer1.transform.localEulerAngles.z > 135 
            && CardPlayer1.transform.localEulerAngles.z < 225)) &&
            (CardPlayer2.transform.localEulerAngles.z < 45 || (CardPlayer2.transform.localEulerAngles.z > 135
            && CardPlayer2.transform.localEulerAngles.z < 225)))
        {
            CardPlayer1.SetFight(true);
            GameObject go = Instantiate(particles1, CardPlayer1.transform.position, Quaternion.identity);
            go.SendMessage("InitializeFinalPosition", CardPlayer2.transform.position);
            CardPlayer2.SetFight(true);
            Debug.Log("Rotation passt1");
            if(myDictionary[Card1].attack + modifications[0] > myDictionary[Card2].attack + modifications[1])
            {
                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - (myDictionary[Card1].attack - myDictionary[Card2].attack));
                Debug.Log("Fall 1.1");
                CardPlayer1.SetFight(false);
                CardPlayer2.SetFight(false);
                CardPlayer1.SetIdle(true);
                CardPlayer2.SetDeath(true);
            }
            else
            {
                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - (myDictionary[Card2].attack - myDictionary[Card1].attack));
                Debug.Log("Fall 1.2");
                CardPlayer1.SetDeath(true);
                CardPlayer2.SetDeath(true);
                CardPlayer2.SetIdle(true);
                CardPlayer1.SetDeath(true);
            }
        }
        else if ((CardPlayer1.transform.localEulerAngles.z < 45 || (CardPlayer1.transform.localEulerAngles.z > 135
            && CardPlayer1.transform.localEulerAngles.z < 225)) &&
            ((CardPlayer2.transform.localEulerAngles.z > 45 && CardPlayer2.transform.localEulerAngles.z < 135)
            || (CardPlayer2.transform.localEulerAngles.z < 315 && CardPlayer2.transform.localEulerAngles.z > 225)))
        {
            CardPlayer1.SetFight(true);
            GameObject go = Instantiate(particles1, CardPlayer1.transform.position, Quaternion.identity);
            go.SendMessage("InitializeFinalPosition", CardPlayer2.transform.position);
            CardPlayer2.SetDefense(true);
            Debug.Log("Rotation passt2");          
            if (myDictionary[Card1].attack + modifications[0] > myDictionary[Card2].defense + modifications[1])
            {
                Debug.Log("Destroying Card2");
                Debug.Log("Fall 2.1");
                CardPlayer1.SetFight(false);
                CardPlayer2.SetDefense(false);
                CardPlayer1.SetIdle(true);
                CardPlayer2.SetDeath(true);
            }
            else
            {
                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - (myDictionary[Card2].defense - myDictionary[Card1].attack));
                Debug.Log("Fall 2.2");
                CardPlayer1.SetFight(false);
                CardPlayer2.SetDefense(false);
                CardPlayer1.SetIdle(true);
                CardPlayer2.SetIdle(true);
            }
        }
        else if ((CardPlayer2.transform.localEulerAngles.z < 45 || (CardPlayer2.transform.localEulerAngles.z > 135
            && CardPlayer2.transform.localEulerAngles.z < 225)) &&
            (CardPlayer1.transform.localEulerAngles.z > 45 && CardPlayer1.transform.localEulerAngles.z < 135
            || (CardPlayer1.transform.localEulerAngles.z < 315 && CardPlayer1.transform.localEulerAngles.z > 225)))
        {
            CardPlayer1.SetDefense(true);
            CardPlayer2.SetFight(true);
            GameObject go = Instantiate(particles1, CardPlayer2.transform.position, Quaternion.identity);
            go.SendMessage("InitializeFinalPosition", CardPlayer1.transform.position);
            Debug.Log("Rotation passt3");
            if (myDictionary[Card2].attack + modifications[0] > myDictionary[Card1].defense + modifications[1])
            {
                Debug.Log("Destroying Card1");
                Debug.Log("Fall 3.1");
                CardPlayer2.SetFight(false);
                CardPlayer1.SetDefense(false);
                CardPlayer2.SetIdle(true);
                CardPlayer1.SetDeath(true);
            }
            else
            {
                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - (myDictionary[Card1].defense - myDictionary[Card2].attack));
                Debug.Log("Fall 3.2");
                CardPlayer2.SetFight(false);
                CardPlayer1.SetDefense(false);
                CardPlayer1.SetIdle(true);
                CardPlayer2.SetIdle(true);
            }
        }
        else
        {
            Debug.Log("nichts passt :(");
        }

    }

}
