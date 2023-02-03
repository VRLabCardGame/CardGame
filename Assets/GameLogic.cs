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

    public GameObject particles0;
    public GameObject particles1;
    public GameObject particles2;
    public GameObject particles3;
    GameObject attackParticles2;
    GameObject attackParticles1;

    public SpellZone spellZonePlayer1;
    public SpellZone spellZonePlayer2;

    string activeSpellCard;

    bool gameEnded = false;



    public GameObject[] atower1;
    public GameObject[] atower2;
    public GameObject[] atower3;
    public GameObject[] atower4;
    public GameObject[] atower5;
    public GameObject[] atower6;
    public GameObject[] atower7;
    public GameObject[] atower8;
    public GameObject[] atower9;
    public GameObject[] atower10;
    public GameObject[][] atower = new GameObject[10][];

    public GameObject[] btower1;
    public GameObject[] btower2;
    public GameObject[] btower3;
    public GameObject[] btower4;
    public GameObject[] btower5;
    public GameObject[] btower6;
    public GameObject[] btower7;
    public GameObject[] btower8;
    public GameObject[] btower9;
    public GameObject[] btower10;
    public GameObject[][] btower = new GameObject[10][];

    public int lifePlayer1 = 10;
    public int lifePlayer2 = 10;
    public int lifePlayer1new = 10;
    public int lifePlayer2new = 10;

    bool fightZoneLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        myDictionary.Add("dog", (2, 2, 0));
        myDictionary.Add("fox", (4, 1, 2));
        myDictionary.Add("fish", (1, 3, 1));
        myDictionary.Add("fish_blue", (2,2,1));
        myDictionary.Add("turtle", (0, 4, 1));
        myDictionary.Add("turtle_b", (1, 2, 1));
        myDictionary.Add("fox_b", (2, 2, 2));
        myDictionary.Add("dragon", (3, 1, 2));
        myDictionary.Add("dragon_b", (4, 0, 2));
        myDictionary.Add("ape", (3, 2, 3));
        myDictionary.Add("ape_b", (1, 4, 3));
        myDictionary.Add("snake", (3, 0, 3));
        myDictionary.Add("snake_b", (2, 1, 3));
        myDictionary.Add("dog_b", (3, 0, 0));
        myDictionary.Add("bird", (2, 2, 0));
        myDictionary.Add("bird_b", (2, 1, 0));
        myDictionary.Add("player", (0, 0, -1));


        atower1 = GameObject.FindGameObjectsWithTag("atower1");
        atower2 = GameObject.FindGameObjectsWithTag("atower2");
        atower3 = GameObject.FindGameObjectsWithTag("atower3");
        atower4 = GameObject.FindGameObjectsWithTag("atower4");
        atower5 = GameObject.FindGameObjectsWithTag("atower5");
        atower6 = GameObject.FindGameObjectsWithTag("atower6");
        atower7 = GameObject.FindGameObjectsWithTag("atower7");
        atower8 = GameObject.FindGameObjectsWithTag("atower8");
        atower9 = GameObject.FindGameObjectsWithTag("atower9");
        atower10 = GameObject.FindGameObjectsWithTag("atower10");

        atower[0] = atower1;
        atower[1] = atower2;
        atower[2] = atower3;
        atower[3] = atower4;
        atower[4] = atower5;
        atower[5] = atower6;
        atower[6] = atower7;
        atower[7] = atower8;
        atower[8] = atower9;
        atower[9] = atower10;

        btower1 = GameObject.FindGameObjectsWithTag("btower1");
        btower2 = GameObject.FindGameObjectsWithTag("btower2");
        btower3 = GameObject.FindGameObjectsWithTag("btower3");
        btower4 = GameObject.FindGameObjectsWithTag("btower4");
        btower5 = GameObject.FindGameObjectsWithTag("btower5");
        btower6 = GameObject.FindGameObjectsWithTag("btower6");
        btower7 = GameObject.FindGameObjectsWithTag("btower7");
        btower8 = GameObject.FindGameObjectsWithTag("btower8");
        btower9 = GameObject.FindGameObjectsWithTag("btower9");
        btower10 = GameObject.FindGameObjectsWithTag("btower10");

        btower[0] = btower1;
        btower[1] = btower2;
        btower[2] = btower3;
        btower[3] = btower4;
        btower[4] = btower5;
        btower[5] = btower6;
        btower[6] = btower7;
        btower[7] = btower8;
        btower[8] = btower9;
        btower[9] = btower10;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode(atower10);
            Explode(atower1);
            Explode(atower2);
            Explode(atower3);
            Explode(atower4);
            Explode(atower5);
            Explode(atower6);
            Explode(atower7);
            Explode(atower8);
            Explode(atower9);

        }
    }

    public List<int> UseElements(string Card1, string Card2)
    {
        int modificationCard1 = 0;
        int modificationCard2 = 0;
        if (myDictionary[Card1].element != -1 && myDictionary[Card2].element != -1)
        {
            if (myDictionary[Card1].element - myDictionary[Card2].element == -1 || myDictionary[Card1].element - myDictionary[Card2].element == 3)
            {
                modificationCard1 = 2;
            }
            else if (myDictionary[Card1].element - myDictionary[Card2].element == 1 || myDictionary[Card1].element - myDictionary[Card2].element == -3)
            {
                modificationCard2 = 2;
            }
        }
        List<int> modifs = new List<int>();
        modifs.Add(modificationCard1);
        modifs.Add(modificationCard2);

        if(myDictionary[Card1].element == 0)
        {
            attackParticles1 = particles0;
        }
        else if(myDictionary[Card1].element == 1)
        {
            attackParticles1 = particles1;
        }
        else if (myDictionary[Card1].element == 2)
        {
            attackParticles1 = particles2;
        }
        else
        {
            attackParticles1 = particles3;
        }

        if (myDictionary[Card2].element == 0)
        {
            attackParticles2 = particles0;
        }
        else if (myDictionary[Card2].element == 1)
        {
            attackParticles2 = particles1;
        }
        else if (myDictionary[Card2].element == 2)
        {
            attackParticles2 = particles2;
        }
        else
        {
            attackParticles2 = particles3;
        }

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
        if (activeSpellCard == "Fire+" || activeSpellCard == "FireDef+")
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesFeuer"))
            {
                var emission = GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
            }
        }
        if (activeSpellCard == "Nature+" || activeSpellCard == "NatureDef+")
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesNatur"))
            {
                var emission = GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
            }
        }
        if (activeSpellCard == "Water+" || activeSpellCard == "WaterDef+")
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesWasser"))
            {
                var emission = GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
            }
        }
        if (activeSpellCard == "Lightning+" || activeSpellCard == "LightningDef+")
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesBlitz"))
            {
                var emission = GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
            }
        }
        
    }
    void EndUseSpellCard(Collider other)
    {
        activeSpellCard = null;
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesFeuer"))
        {
            var emission = GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesWasser"))
        {
            var emission = GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesBlitz"))
        {
            var emission = GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("ParticlesNatur"))
        {
            var emission = GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
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
        else if (activeSpellCard == "FireDef+")
        {
            if (myDictionary[Card1].element == 2)
            {
                modifs.Add(Card1, (myDictionary[Card1].defense + 2, myDictionary[Card1].defense + 2));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 2)
            {
                modifs.Add(Card2, (myDictionary[Card1].defense + 2, myDictionary[Card2].defense + 2));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if (activeSpellCard == "NatureDef+")
        {
            if (myDictionary[Card1].element == 3)
            {
                modifs.Add(Card1, (myDictionary[Card1].defense + 2, myDictionary[Card1].defense + 2));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 3)
            {
                modifs.Add(Card2, (myDictionary[Card1].defense + 2, myDictionary[Card2].defense + 2));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if (activeSpellCard == "WaterDef+")
        {
            if (myDictionary[Card1].element == 1)
            {
                modifs.Add(Card1, (myDictionary[Card1].defense + 2, myDictionary[Card1].defense + 2));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 1)
            {
                modifs.Add(Card2, (myDictionary[Card1].defense + 2, myDictionary[Card2].defense + 2));
            }
            else
            {
                modifs.Add(Card2, (myDictionary[Card2].attack, myDictionary[Card2].defense));
            }
        }
        else if (activeSpellCard == "LightningDef+")
        {
            if (myDictionary[Card1].element == 0)
            {
                modifs.Add(Card1, (myDictionary[Card1].defense + 2, myDictionary[Card1].defense + 2));
            }
            else
            {
                modifs.Add(Card1, (myDictionary[Card1].attack, myDictionary[Card1].defense));
            }
            if (myDictionary[Card2].element == 0)
            {
                modifs.Add(Card2, (myDictionary[Card1].defense + 2, myDictionary[Card2].defense + 2));
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
        if (!gameEnded && !fightZoneLocked)
        {
            fightZoneLocked = true;
            Debug.Log("Calculating Fight...");
            Debug.Log("Card1: " + Card1);
            Debug.Log("Card2: " + Card2);
            CardPlayer1 = GameObject.Find(Card1).GetComponent<Card>();
            CardPlayer2 = GameObject.Find(Card2).GetComponent<Card>();
            if (!CardPlayer1.IsDead() && !CardPlayer2.IsDead())
            {
                StartCoroutine(FightCoroutine(Card1, Card2));
            }
            fightZoneLocked = false;
        }
    }

    
    IEnumerator FightCoroutine(string Card1, string Card2)
    {
        
        modifications = UseElements(Card1, Card2);
        var Card1Object = GameObject.Find(Card1).transform.parent.gameObject;
        var Card2Object = GameObject.Find(Card2).transform.parent.gameObject;
        Dictionary<string, (int attack, int defense)> fightDictionary = CalculateSpellCard(Card1, Card2);
        Debug.Log(CardPlayer1.transform.parent.transform.localEulerAngles.z + ", x: " + CardPlayer1.transform.parent.transform.localEulerAngles.x + ", y: " + CardPlayer1.transform.parent.transform.localEulerAngles.y);
        Debug.Log(CardPlayer2.transform.parent.transform.localEulerAngles.z + ", x2: " + CardPlayer2.transform.parent.transform.localEulerAngles.x + ", y: " + CardPlayer2.transform.parent.transform.localEulerAngles.y);
        if ((CardPlayer1.transform.parent.transform.localEulerAngles.y < 45 || CardPlayer1.transform.parent.transform.localEulerAngles.y > 315 ||
            (CardPlayer1.transform.parent.transform.localEulerAngles.y > 135
            && CardPlayer1.transform.parent.transform.localEulerAngles.y < 225)) &&
            (CardPlayer2.transform.parent.transform.localEulerAngles.y < 45 || CardPlayer2.transform.parent.transform.localEulerAngles.y > 315 ||
            (CardPlayer2.transform.parent.transform.localEulerAngles.y > 135
            && CardPlayer2.transform.parent.transform.localEulerAngles.y < 225)))
        {
            CardPlayer1.transform.LookAt(CardPlayer2.transform.position);
            CardPlayer2.transform.LookAt(CardPlayer1.transform.position);
            //CardPlayer1.transform.rotation = Quaternion.LookRotation(CardPlayer2.transform.forward);
            //CardPlayer2.transform.rotation = Quaternion.LookRotation(CardPlayer1.transform.forward);
            yield return new WaitForSeconds(2);
            CardPlayer1.SetFight0();
            GameObject go = Instantiate(attackParticles1, CardPlayer1.transform.position, Quaternion.identity);
            GameObject go1 = Instantiate(attackParticles2, CardPlayer2.transform.position, Quaternion.identity);
            CardPlayer2.SetFight0();
            Debug.Log("Rotation passt1");
            Debug.Log(fightDictionary[Card1] + " " + modifications[0] + ", " + fightDictionary[Card2] + " " + modifications[1]);
            yield return new WaitForSeconds(0.75f);
            go.SendMessage("InitializeFinalPosition", CardPlayer2.transform.position);
            go1.SendMessage("InitializeFinalPosition", CardPlayer1.transform.position);
            if (fightDictionary[Card1].attack + modifications[0] > fightDictionary[Card2].attack + modifications[1])
            {
                

                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - ((fightDictionary[Card1].attack + modifications[0]) - (fightDictionary[Card2].attack + modifications[1])));
                Debug.Log("Fall 1.1");
                CardPlayer1.SetIdle0();
                yield return new WaitForSeconds(0.6f);
                CardPlayer2.SetDefense0();
                yield return new WaitForSeconds(1.5f);
                CardPlayer2.SetDeath0();
                Destroy(Card2Object, 6);

                lifePlayer2new = lifePlayer2new - ((fightDictionary[Card1].attack + modifications[0]) - (fightDictionary[Card2].attack + modifications[1]));
                DestroyTower(false, lifePlayer2, lifePlayer2new);
                Debug.Log(lifePlayer2 + " " + lifePlayer2new);
                lifePlayer2 = lifePlayer2new;
                yield return new WaitForSeconds(5);
                CardPlayer2.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (fightDictionary[Card1].attack + modifications[0] == fightDictionary[Card2].attack + modifications[1])
            {
                Debug.Log("Fall 1.3");
                CardPlayer1.SetDeath0();
                CardPlayer2.SetDeath0();
                Destroy(Card1Object, 6);
                Destroy(Card2Object, 6);
            }
            else
            {
                

                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - ((fightDictionary[Card2].attack + modifications[1]) - (fightDictionary[Card1].attack + modifications[0])));
                Debug.Log("Fall 1.2");
                CardPlayer2.SetIdle0();
                yield return new WaitForSeconds(0.6f);
                CardPlayer1.SetDefense0();
                yield return new WaitForSeconds(1.5f);
                CardPlayer1.SetDeath0(); 
                Destroy(Card1Object, 6);

                lifePlayer1new -= ((fightDictionary[Card2].attack + modifications[1]) - (fightDictionary[Card1].attack + modifications[0]));
                DestroyTower(true, lifePlayer1, lifePlayer1new);
                Debug.Log(lifePlayer1 +" " + lifePlayer1new);
                lifePlayer1 = lifePlayer1new;
                yield return new WaitForSeconds(5);
                CardPlayer2.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if ((CardPlayer1.transform.parent.transform.localEulerAngles.y < 45 || CardPlayer1.transform.parent.transform.localEulerAngles.y > 315 ||
            (CardPlayer1.transform.parent.transform.localEulerAngles.y > 135
            && CardPlayer1.transform.parent.transform.localEulerAngles.y < 225)) &&
            ((CardPlayer2.transform.parent.transform.localEulerAngles.y > 45 && CardPlayer2.transform.parent.transform.localEulerAngles.y < 135)
            || (CardPlayer2.transform.parent.transform.localEulerAngles.y < 315 && CardPlayer2.transform.parent.transform.localEulerAngles.y > 225)))
        {
            CardPlayer1.transform.LookAt(CardPlayer2.transform.position);
            CardPlayer2.transform.LookAt(CardPlayer1.transform.position);
            //CardPlayer1.transform.rotation = Quaternion.LookRotation(CardPlayer2.transform.forward);
            //CardPlayer2.transform.rotation = Quaternion.LookRotation(CardPlayer1.transform.forward);
            yield return new WaitForSeconds(2);
            CardPlayer1.SetFight0();
            GameObject go = Instantiate(attackParticles1, CardPlayer1.transform.position, Quaternion.identity);
            
            Debug.Log("Rotation passt2");
            yield return new WaitForSeconds(0.75f);
            go.SendMessage("InitializeFinalPosition", CardPlayer2.transform.position);
            if (fightDictionary[Card1].attack + modifications[0] > fightDictionary[Card2].defense + modifications[1])
            {
                Debug.Log("Destroying Card2");
                Debug.Log("Fall 2.1");
                CardPlayer1.SetIdle0();
                yield return new WaitForSeconds(0.6f);
                CardPlayer2.SetDefense0();
                yield return new WaitForSeconds(1.5f);
                CardPlayer2.SetDeath0(); 
                Destroy(Card2Object, 6);
                yield return new WaitForSeconds(5);
                CardPlayer1.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                

                LifePlayer1.SetCurrentFill(LifePlayer1.GetCurrentFill() - ((fightDictionary[Card2].defense + modifications[1]) - (fightDictionary[Card1].attack + modifications[0])));
                Debug.Log("Fall 2.2");
                CardPlayer1.SetIdle0();
                yield return new WaitForSeconds(0.6f);
                CardPlayer2.SetDefense0();
                yield return new WaitForSeconds(1.5f);
                CardPlayer2.SetIdle0();

                lifePlayer1new -= ((fightDictionary[Card2].defense + modifications[1]) - (fightDictionary[Card1].attack + modifications[0]));
                DestroyTower(true, lifePlayer1, lifePlayer1new);
                lifePlayer1 = lifePlayer1new;
                yield return new WaitForSeconds(5);
                CardPlayer1.transform.eulerAngles = new Vector3(0, 0, 0);
                CardPlayer2.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if ((CardPlayer2.transform.parent.transform.localEulerAngles.y < 45 || CardPlayer2.transform.parent.transform.localEulerAngles.y > 315 ||
            (CardPlayer2.transform.parent.transform.localEulerAngles.y > 135
            && CardPlayer2.transform.parent.transform.localEulerAngles.y < 225)) &&
            (CardPlayer1.transform.parent.transform.localEulerAngles.y > 45 && CardPlayer1.transform.parent.transform.localEulerAngles.y < 135
            || (CardPlayer1.transform.parent.transform.localEulerAngles.y < 315 && CardPlayer1.transform.parent.transform.localEulerAngles.y > 225)))
        {
            CardPlayer1.transform.LookAt(CardPlayer2.transform.position);
            CardPlayer2.transform.LookAt(CardPlayer1.transform.position);
            //CardPlayer1.transform.rotation = Quaternion.LookRotation(CardPlayer2.transform.forward);
            //CardPlayer2.transform.rotation = Quaternion.LookRotation(CardPlayer1.transform.forward);
            yield return new WaitForSeconds(2);

            CardPlayer2.SetFight0();
            GameObject go = Instantiate(attackParticles2, CardPlayer2.transform.position, Quaternion.identity);
            Debug.Log("Rotation passt3");
            yield return new WaitForSeconds(0.75f);
            go.SendMessage("InitializeFinalPosition", CardPlayer1.transform.position);
            if (fightDictionary[Card2].attack + modifications[1] > fightDictionary[Card1].defense + modifications[0])
            {
                Debug.Log("Destroying Card1");
                Debug.Log("Fall 3.1");
                CardPlayer2.SetIdle0();
                yield return new WaitForSeconds(0.6f);
                CardPlayer1.SetDefense0();
                yield return new WaitForSeconds(1.5f);
                CardPlayer1.SetDeath0();
                Destroy(Card1Object, 3);
                yield return new WaitForSeconds(5);
                CardPlayer2.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                

                LifePlayer2.SetCurrentFill(LifePlayer2.GetCurrentFill() - ((fightDictionary[Card1].defense + modifications[0]) - (fightDictionary[Card2].attack + modifications[1])));
                Debug.Log("Fall 3.2");
                CardPlayer2.SetIdle0();
                yield return new WaitForSeconds(0.6f);
                CardPlayer1.SetDefense0();
                yield return new WaitForSeconds(1.5f);
                CardPlayer2.SetIdle0();

                lifePlayer2new -= ((fightDictionary[Card1].defense + modifications[0]) - (fightDictionary[Card2].attack + modifications[1]));
                DestroyTower(false, lifePlayer2, lifePlayer2new);
                lifePlayer2 = lifePlayer2new;
                yield return new WaitForSeconds(5);
                CardPlayer1.transform.eulerAngles = new Vector3(0, 0, 0);
                CardPlayer2.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            Debug.Log("nichts passt :(");
        }
        
        if(LifePlayer1.GetCurrentFill() <= 0 || LifePlayer2.GetCurrentFill() <= 0)
        {
            gameEnded = true;
        }

    }


    public void DestroyTower(bool player1, int lifeBefore, int lifeAfter)
    {
        if(lifeAfter < 0)
        {
            lifeAfter = 0;
        }
        if (player1)
        {
            for(int i = lifeBefore; i > lifeAfter; i--)
            {
                Explode(atower[i-1]); // i-1?
            }
        }
        else
        {
            for (int i = lifeBefore; i > lifeAfter; i--)
            {
                Explode(btower[i-1]); // i-1?
            }
        }
    }


    public void Explode(GameObject[] fragments)
    {
        foreach(GameObject fragment in fragments)
        {
            var rb = fragment.transform.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(Random.Range(1, 2), fragment.transform.position, 2);
            Destroy(fragment, 2);
        }

    
    }
    
}
