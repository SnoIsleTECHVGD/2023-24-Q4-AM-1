
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleCode : MonoBehaviour
{
    //code for battle, gonna focus on card first tho
    #region refrences and assets
    public GameObject[] cards; // card ref
    public Transform[] BattlePoints;// battle point ref
    public Transform[] cardTransform;
    public int playerLoc;
    public GameObject Enemy; // enemy ref
    public GameObject player; // player ref
    public List <GameObject> currentDeck;// the players current deck, may need to figure out how to set and remove values
    public List <GameObject> deckSave; // The deck saved externally, will be used when reseting players active deck, and during reshuffles as well
    private bool turnActive, turnInactive, turnReady; //turn values
    public Transform currentPlayerLoc; // where the player currently is
    public List <GameObject> activeHand; // what the player has in their hand
    public int RandomValue;// randomizes the order for when cards are drawn
    public GameObject nextDraw, addToHand; // for when cards influnce draw order, and we cant just randomize it out 
    public int cardLimit, drawCard, cardsInHand, deckSize; // card and deck ints
    public List <int> pointVal;
    public List <GameObject> discard;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentDeck = deckSave;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnActive == true)
        {
            player.GetComponent<PlayerStats>().PlayerEffects();
            Enemy.GetComponent<EnemyStats>().EnemyEffects();
            RoundStart();
        }
        if (Enemy.GetComponent<EnemyStats>().health >= 0)
        {
            ExitCombat();
        }
        if (player.GetComponent<PlayerStats>().health == 0)
        {
            //skill issue
            GameOver();
        }
        if (turnReady == true)
        {

           turnReady = false; 
        }

        if (turnActive == false)
        {
            RoundEnd();
        }

    }
    #region round controller
    public void RoundStart()
    {
        DrawHand();
        
    }
 
    public void RoundEnd()
    {
        turnActive = false;
        pointVal.Add(GetComponent<EnemyStats>().point1);
        pointVal.Add(GetComponent<EnemyStats>().point2);
        pointVal.Add(GetComponent<EnemyStats>().point3);
        pointVal.Add(GetComponent<EnemyStats>().point4);
        pointVal.Add(GetComponent<EnemyStats>().point5);
        pointVal.Add(GetComponent<EnemyStats>().point6);
        
        

    }
    public void ExitCombat()
    {
        // do exit combat function
    }
    public void GameOver()
    {
        // end game
    }
    #endregion

    #region card and deck functions
    public void DrawHand()
    {
        while (cardLimit < cardsInHand)
        {
            if(nextDraw != null)
            {
                activeHand.Add(nextDraw);
                nextDraw = null;
            }
            if (nextDraw == null)
            {
                RandomValue = Random.Range(0, deckSize);

                activeHand.Add(currentDeck[RandomValue]);
                currentDeck.RemoveAt(RandomValue);
                turnActive = true;
            }

        }
        if(cardLimit == cardsInHand)
        {
          turnReady = true;
        }
    }

    #endregion
}
