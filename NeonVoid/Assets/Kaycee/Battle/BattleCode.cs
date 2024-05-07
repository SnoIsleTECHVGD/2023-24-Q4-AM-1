
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleCode : MonoBehaviour
{
    //code for battle, gonna focus on card first tho
    #region refrences and assets
    public Turn turn;
    public enum Turn { player, enemy };
    public Transform[] cardTransform;
    public EnemyStats enemyStats;
    public PlayerStats playerStats;
    public GameObject Enemy; // enemy ref
    private GameObject player; // player ref
    public List<CardCode> drawPile = new List<CardCode>();
    public List<CardCode> discardPile = new List<CardCode>();
    public List<CardCode> cardsInHand = new List<CardCode>();
    private bool turnActive, turnInactive, turnReady; //turn values
    public int RandomValue;// randomizes the order for when cards are drawn
    public GameObject nextDraw, addToHand; // for when cards influnce draw order, and we cant just randomize it out 
    public int cardLimit, drawCard, deckSize; // card and deck ints
    public List<GameObject> discard;
    public List<CardUI> InstantiatedCards = new List<CardUI>();
    public int energy, maxEnergy; // I be maxing to krusty krab pizza edits 
    public CardUI selectedCard; // I select that gyatt like ice spice smoking pot
    public GameManager gameManager; // I manage her game so she game on my manager 
    CardEffects cardEffects;




    #endregion
    public void Awake()
    {
        BeginCombat();

        cardEffects = FindObjectOfType<CardEffects>();
    }

    public void PlayedCard(CardUI cardUI)
    {
        cardEffects.AvailableActions(cardUI.cards, playerStats, enemyStats);
        energy -= cardUI.cards.cost;
        selectedCard = null;
        cardUI.gameObject.SetActive(false);
        cardsInHand.Remove(cardUI.cards);
        DiscardCard(cardUI.cards);
        Debug.Log(energy);
    }

    
    public void BeginCombat()
    {
        //trigger this first!
        drawPile.Clear(); //incase data is left over for whatever reason 
        energy = maxEnergy;
      
        foreach (CardCode card in cardsInHand)
        {
            DiscardCard(card);
        }
        discardPile.AddRange(gameManager.playerDeck);
        ShuffleCards();
        DrawCards(cardLimit);
        turn = Turn.player;

    }
    #region round controller
    public void NewRound()
    {
        if(turn == Turn.player)
        {
            foreach (CardCode card in cardsInHand)
            {
                DiscardCard(card);
                
            }
            foreach(CardUI cardUI in InstantiatedCards)
            {
                cardUI.gameObject.SetActive(true);
            }
            turn = Turn.enemy;
            StartCoroutine(EnemyTurn());

        }
        else
        {
            turn = Turn.player;
            energy = maxEnergy;
            DrawCards(cardLimit);

        }
        if (drawPile.Count == 0)
        {
            ShuffleCards();
        }
        foreach (CardUI cardUI in InstantiatedCards)
        {
            if (cardUI.gameObject.activeSelf)
                //Instantiate( cardUI.transform.position, Quaternion.identity);

            cardUI.gameObject.SetActive(false);
            cardsInHand.Remove(cardUI.cards);
        }
      
        
        
    } 
    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1); //place holder for now, change to length of enemies turn or animation
        Enemy.GetComponent<EnemyTurn>().isEnemyTurn = true;
        Debug.Log("EnemyTurn GO!");
        NewRound();
    }
    
    #endregion

    #region card and deck functions
    public void ShuffleCards()
    {
        discardPile.Shuffle();
        drawPile = discardPile;
        //discardPile.Clear();
    }
    public void DisplayCardInHand(CardCode card)
    {
        Debug.Log("trigger test");
        CardUI cardUI = InstantiatedCards[cardsInHand.Count - 1];
        cardUI.LoadCard(card);
        cardUI.gameObject.SetActive(true);
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
            DisplayCardInHand(drawPile[0]);
        }

        
    }
    public void DiscardCard(CardCode card)
    {
        discardPile.Add(card);
         }

        #endregion
    }
