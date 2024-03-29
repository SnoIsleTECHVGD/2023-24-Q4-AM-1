using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject enemyRef, playerRef;
    public string enemyName;
    public bool Enemy01, Boss;
    public string[] barkText;
    public GameObject[] LocationPoints;
    public int currentPlayerLoc, attackPoint;
    public bool dead, infliction, utilityBool;// Utility is just gonna be something i set true or false for special mechanics if need be 
    public int health, block, overHeat, electrified, electrifiedEnemy, overHeatEnemy, healthStorage, staggerHealth;// health and various stats
    private int point1, point2, point3, point4, point5, point6; // atk patterns for ai
    public int damage, specialEffect; //damage and special infliction cases
    public string inflictionNameSpace;
    public int randomizedAtkVal, moveLimit, moveStorage;

    public bool isWhiling;
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
        if(utilityBool == true)
        {
            if(Boss == true)
            {
                staggerHealth = healthStorage - health;
                if(staggerHealth >= 20)
                {
                    point1 = 7;
                    point2 = 7;
                    point3 = 7;
                    point4 = 7;
                    point5 = 7;
                    point6 = 7;
                }
            }
        }
    }
    //what i'll probably do is have multiple tags that will dictate what script to call on, that way we might be able to keep this script as the 'universal' ai script, with other minor ai scripts to go with it
    // Initial attack brodcast, dictates where the enemy will hit next on round start
     IEnumerator AttackBroadcast() 
    {
        isWhiling = true;
        while (attackPoint != currentPlayerLoc)
        {
            
            attackPoint++;
            
        }
        yield return null;
        isWhiling = false;
        
    }
     public void EnemyMechanics()
    {
        if (Boss == true)
        {
            randomizedAtkVal = Random.Range(0, moveLimit);
            if (moveLimit == 0 && moveLimit != moveStorage)
            {
                point1 = attackPoint;
                point2 = attackPoint - 2;
                point3 = attackPoint + 2;
                moveLimit = moveStorage;
                point4 = 7;
                point5 = 7;
                point6 = 7;

            }
            if (moveLimit == 1 && moveLimit != moveStorage)
            {
                point1 = attackPoint;
                point2 = attackPoint - 1;
                point4 = 7;
                point5 = 7;
                point6 = 7;
                point3 = attackPoint + 1;
                moveLimit = moveStorage;
            }
            if (moveLimit == 2 && moveLimit != moveStorage)
            {
                point1 = 7;
                point2 = attackPoint - 1;
                point3 = attackPoint - 2;
                point4 = attackPoint - 3;
                point5 = attackPoint - 4;
                point6 = attackPoint - 5;
                moveLimit = moveStorage;
            }
            if (moveLimit == 3 && moveLimit != moveStorage)
            {

            }
            if (health >= health * 0.5f && utilityBool!= true)
            {
                point1 = 7;
                point2 = 7;
                point3 = 7;
                point4 = 7;
                point5 = 7;
                point6 = 7;
                utilityBool = true;
                healthStorage = health;
            }
            if (utilityBool == true)
            {
                point1 = 1;
                point2 = 2;
                point3 = 3;
                point4 = 4;
                point5 = 5;
                point6 = 6;
                
            }
        else
        {
            randomizedAtkVal = Random.Range(0, moveLimit);
            EnemyMechanics();
        }
        }
    }
    public void EnemyEffects()
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
