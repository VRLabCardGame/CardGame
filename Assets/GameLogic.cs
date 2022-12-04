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
    public SpellZone spellZonePlayer1;
    public SpellZone spellZonePlayer2;

    string activeSpellCard;



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

    void OnEnable()
    {
        spellZonePlayer1.onTriggerEnter.AddListener(UseSpellCard);
        spellZonePlayer2.onTriggerEnter.AddListener(UseSpellCard);
        spellZonePlayer1.onTriggerExit.AddListener(EndUseSpellCard);
        spellZonePlayer2.onTriggerExit.AddListener(EndUseSpellCard);
    }

    void OnDisable()
    {
        spellZonePlayer1.onTriggerEnter.RemoveListener(UseSpellCard);
        spellZonePlayer2.onTriggerEnter.RemoveListener(UseSpellCard);
        spellZonePlayer1.onTriggerExit.RemoveListener(EndUseSpellCard);
        spellZonePlayer2.onTriggerExit.RemoveListener(EndUseSpellCard);
    }

    void UseSpellCard(Collider other)
    {
        activeSpellCard = other.transform.name;
    }
    void EndUseSpellCard(Collider other)
    {
        activeSpellCard = null;
    }

    Dictionary<string, (int attack, int defense)> CalculateSpellCard(string Card1, string Card2)
    {
        Dictionary<string, (int attack, int defense)> modifs = new Dictionary<string, (int attack, int defense)>();
        if (activeSpellCard == "SwitchAttackDefense") {
            modifs.Add(Card1, (myDictionary[Card1].defense, myDictionary[Card1].attack));
            modifs.Add(Card2, (myDictionary[Card2].defense, myDictionary[Card2].attack));
        }
        else if(activeSpellCard == "SwitchMonstersValues") {
            modifs.Add(Card1, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            modifs.Add(Card2, (myDictionary[Card1].attack, myDictionary[Card1].defense));
        }
        else if (activeSpellCard == "Fire+")
        {
            if(myDictionary[Card1].element == 2)
            {
                modifs.Add(Card1, (myDictionary[Card1].attack + 2, myDictionary[Card1].defense));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 2)
            {
                modifs.Add(Card2, (myDictionary[Card2].attack + 2, myDictionary[Card2].defense));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if (activeSpellCard == "Nature+")
        {
            if (myDictionary[Card1].element == 3)
            {
                modifs.Add(Card1, (myDictionary[Card1].attack + 2, myDictionary[Card1].defense));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 3)
            {
                modifs.Add(Card2, (myDictionary[Card2].attack + 2, myDictionary[Card2].defense));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if (activeSpellCard == "Water+")
        {
            if (myDictionary[Card1].element == 1)
            {
                modifs.Add(Card1, (myDictionary[Card1].attack + 2, myDictionary[Card1].defense));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 1)
            {
                modifs.Add(Card2, (myDictionary[Card2].attack + 2, myDictionary[Card2].defense));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if (activeSpellCard == "Lightning+")
        {
            if (myDictionary[Card1].element == 0)
            {
                modifs.Add(Card1, (myDictionary[Card1].attack + 2, myDictionary[Card1].defense));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 0)
            {
                modifs.Add(Card2, (myDictionary[Card2].attack + 2, myDictionary[Card2].defense));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if(activeSpellCard == "ChangeElementOrder")
        {
            if (myDictionary[Card1].element - myDictionary[Card2].element == -1 || myDictionary[Card1].element - myDictionary[Card2].element == 3)
            {
                modifs.Add(Card1, (myDictionary[Card1].attack - 4, myDictionary[Card1].defense - 4));
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
            else if (myDictionary[Card1].element - myDictionary[Card2].element == 1 || myDictionary[Card1].element - myDictionary[Card2].element == -3)
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
                modifs.Add(Card2, (myDictionary[Card2].attack - 4, myDictionary[Card2].defense - 4));
            }
        }
        else
        {
            modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
        }
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
        Dictionary<string, (int attack, int defense)> fightDictionary = CalculateSpellCard(Card1, Card2);
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
            if(fightDictionary[Card1].attack + modifications[0] > fightDictionary[Card2].attack + modifications[1])
            {
                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - (fightDictionary[Card1].attack + modifications[0] - fightDictionary[Card2].attack + modifications[1]));
                Debug.Log("Fall 1.1");
                //CardPlayer1.SetFight(false);
                //CardPlayer2.SetFight(false);
                CardPlayer1.SetIdle(true);
                CardPlayer2.SetDeath(true);
            }
            else
            {
                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - (fightDictionary[Card2].attack + modifications[1] - fightDictionary[Card1].attack + modifications[0]));
                Debug.Log("Fall 1.2");
                CardPlayer1.SetFight(true);
                CardPlayer2.SetFight(true);
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
            if (fightDictionary[Card1].attack + modifications[0] > fightDictionary[Card2].defense + modifications[1])
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
                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - (fightDictionary[Card2].defense + modifications[1] - fightDictionary[Card1].attack + modifications[0]));
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
            if (fightDictionary[Card2].attack + modifications[0] > fightDictionary[Card1].defense + modifications[1])
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
                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - (fightDictionary[Card1].defense + modifications[0] - fightDictionary[Card2].attack + modifications[1]));
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
