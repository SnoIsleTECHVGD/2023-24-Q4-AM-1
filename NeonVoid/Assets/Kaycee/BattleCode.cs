using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCode : MonoBehaviour
{
    //code for battle, gonna focus on card first tho
    #region refrences and assets
    public GameObject[] cards;
    public Transform[] BattlePoints;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject[] currentDeck;
    public GameObject[] deckSave;
    private bool turnActive, turnInactive;
    public Transform currentPlayerLoc;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
