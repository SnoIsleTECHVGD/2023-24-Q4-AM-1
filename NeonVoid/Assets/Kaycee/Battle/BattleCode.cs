
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleCode : MonoBehaviour
{
    //code for battle, gonna focus on card first tho
    #region refrences and assets
    public bool turn;
    public Transform[] cardTransform;
    private GameObject Enemy; // enemy ref
    private GameObject player; // player ref
    public List<CardCode> drawPile = new List<CardCode>();
    public List<CardCode> discardPile = new List<CardCode>();
    public List <CardCode> cardsInHand = new List<CardCode>();
    private bool turnActive, turnInactive, turnReady; //turn values
    public int RandomValue;// randomizes the order for when cards are drawn
    public GameObject nextDraw, addToHand; // for when cards influnce draw order, and we cant just randomize it out 
    public int cardLimit, drawCard , deckSize; // card and deck ints
    public List <GameObject> discard;
    public int energy, maxEnergy;


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
    public void BeginCombat()
    {
        drawPile.Clear(); //incase data is left over for whatever reason
        energy = maxEnergy;
        ShuffleCards();
    }
    #region round controller
    public void RoundStart()
    {
        if(drawPile.Count == 0)
        {
            ShuffleCards();
        }
        
    }
 
    public void RoundEnd()
    {
        turnActive = false;
        
        //trigger enemy attack
        

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
        discardPile.Shuffle();
        drawPile = discardPile;
        discardPile.Clear();
    }
    public void DrawCards(int DrawAmount)
    {
        int DrawTotal = 0;
        while(DrawTotal < DrawAmount)
        {
            if(drawPile.Count < 1)
            {
                ShuffleCards();
            }
            cardsInHand.Add(drawPile[0]);
            drawPile.Remove(drawPile[0]);
            DrawTotal++;
        }

        
    }

    #endregion
}
