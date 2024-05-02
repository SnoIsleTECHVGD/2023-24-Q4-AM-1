using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject enemyRef, playerRef;
    PlayerStats player;
    public string enemyName;
    public bool Enemy01, Boss;
    public string[] barkText;
    private GameObject[] LocationPoints;
    public int currentPlayerLoc, attackPoint;
    public bool dead, infliction, utilityBool;// Utility is just gonna be something i set true or false for special mechanics if need be 
    public int health, block, overHeat, electrified, electrifiedEnemy, overHeatEnemy, healthStorage, staggerHealth;// health and various stats
    public int point1, point2, point3, point4, point5, point6; // atk patterns for ai
    public int damage, specialEffect; //damage and special infliction cases
    //public List<EnemyAction>
    public AudioSource EnemyAttack; 

    public bool isWhiling;
    void Start()
    {
        enemyRef = this.gameObject;
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      

        
        if (utilityBool == true)
        {
            if (Boss == true)
            {
                staggerHealth = healthStorage - health;
                if (staggerHealth >= 20)
                {
                   
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
    public void raycastTest()
    {
       
    }
    private IEnumerator AttackPlayer()
    {
        //place holder
        yield return new WaitForSeconds(0.5f);
        player.TakeDamage();
        yield return new WaitForSeconds(0.5f);
 
        
    }
     public void EnemyMechanics()
    {
        
    }
    public void EnemyEffects()
    {
        if(overHeatEnemy == 5)
        {
            // do over heat function (end turn), may remain unimplemented?
        }
        if (electrified > 0)
        {
           health = health - electrifiedEnemy;
        }
    }
    public void TakeDMG(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            //combat won
        }
    }
    
}
