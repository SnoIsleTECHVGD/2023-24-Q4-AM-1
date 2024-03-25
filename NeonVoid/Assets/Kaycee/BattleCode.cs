
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleCode : MonoBehaviour
{
    //code for battle, gonna focus on card first tho
    #region refrences and assets
    public GameObject[] cards;
    public Transform[] BattlePoints;
    public GameObject Enemy;
    public GameObject player;
    public GameObject[] currentDeck;// the players current deck, may need to figure out how to set and remove values
    public GameObject[] deckSave; // The deck saved externally, will be used when reseting players active deck, and during reshuffles as well
    private bool turnActive, turnInactive, turnReady; //turn values
    public Transform currentPlayerLoc; // where the player currently is
    public GameObject[] activeHand; // what the player has in their hand
    public int RandomValue;// randomizes the order for when cards are drawn
    public GameObject nextDraw; // for when cards influnce draw order, and we cant just randomize it out 
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentDeck = deckSave;
    }

    // Update is called once per frame
    void Update()
    {
        if(turnActive == true)
        {
            player.GetComponent<PlayerStats>().playerEffects();
            Enemy.GetComponent<EnemyStats>().enemyEffects();
            roundStart();
        }
        if (Enemy.GetComponent<EnemyStats>().health >= 0)
        {
            exitCombat();
        }
        if(player.GetComponent<PlayerStats>().health == 0)
        {
            //skill issue
            gameOver();
        }
        if(turnReady == true)
        {

        }

        if (turnActive == false)
        {
            roundEnd();
        }
        
    }
    public void roundStart()
    {
        
        turnActive = true;
    }
 
    public void roundEnd()
    {
        turnActive = false;
    }
    public void exitCombat()
    {
        // do exit combat function
    }
    public void gameOver()
    {
        // end game
    }
    
}
