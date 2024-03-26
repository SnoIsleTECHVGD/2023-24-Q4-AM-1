using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject enemyRef, playerRef;
    public string enemyName;
    public string[] barkText;
    public GameObject[] LocationPoints;
    public int currentPlayerLoc, attackPoint;
    public bool dead, infliction; 
    public int health, block, overHeat, electrified, electrifiedEnemy, overHeatEnemy;// health and various stats
    private int point1, point2, point3, point4, point5; // atk patterns for ai
    public int damage, specialEffect; //damage and special infliction cases
    public string inflictionNameSpace;
 

    void Start()
    {
        enemyRef = this.gameObject;
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(infliction == true)
        {
            if (inflictionNameSpace == "overheat")
            {
                playerRef.GetComponent<PlayerStats>().overHeatStorage = overHeat;
            }
            if (inflictionNameSpace == "electrified")
            {
                playerRef.GetComponent<PlayerStats>().electrifiedStorage = electrified;
            }
        }
    }
    //ai work, will call this when its time to
    // Initial attack brodcast, dictates where the enemy will hit next on round start
    public void attackBroadcast() 
    {
        while (attackPoint != currentPlayerLoc)
        {

            attackPoint++;
        }
    }
     public void enemyMechanics()
    {
        
    }
    public void enemyEffects()
    {
        if(overHeatEnemy == 5)
        {
            // do over heat function (end turn)
        }
        if (electrified > 0)
        {
           health = health - electrifiedEnemy;
        }
    }
}
