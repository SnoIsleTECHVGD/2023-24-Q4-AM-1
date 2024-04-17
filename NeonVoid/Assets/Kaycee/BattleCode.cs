
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleCode : MonoBehaviour
{
    //code for battle, gonna focus on card first tho
    #region refrences and assets
    public List<CardCode> deck; // card ref
    public Transform[] BattlePoints;// battle point ref
    public Transform[] cardTransform;
    public int playerLoc;
    private GameObject Enemy; // enemy ref
    private GameObject player; // player ref
    public List<CardCode> drawPile = new List<CardCode>();// the players current deck, may need to figure out how to set and remove values
    public List<CardCode> discardPile = new List<CardCode>();
    public List <CardCode> cardsInHand = new List<CardCode>();
    private bool turnActive, turnInactive, turnReady; //turn values
    private Transform currentPlayerLoc; // where the player currently is
 
    public int RandomValue;// randomizes the order for when cards are drawn
    public GameObject nextDraw, addToHand; // for when cards influnce draw order, and we cant just randomize it out 
    public int cardLimit, drawCard , deckSize; // card and deck ints
    public List <int> pointVal;
    public List <GameObject> discard;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
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
        //DrawHand();
        
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
    public void ShuffleCards()
    {
        //discardPile.Shuffle();
    }

    #endregion
}
