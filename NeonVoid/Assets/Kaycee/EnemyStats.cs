using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject enemyRef, playerRef;
    public string enemyName;
    public bool dead, infliction; 
    public int health, block, overHeat, electrified;// health and various stats
    public int point1, point2, point3, point4, point5; // atk patterns for ai
    public int damage, specialEffect; //damage and special infliction cases
    public string inflictionNameSpace;
    void Start()
    {
        enemyRef = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(infliction == true)
        {
            if (inflictionNameSpace == "overheat")
            {

            }
        }
    }
}
