using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health, overHeat, electrified, overHeatStorage, electrifiedStorage, moveAmount;
    public string[] barkTextPlayer;

    public GameObject DeathScript;

    public GameObject BattleMovementObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MovePlayer()
    {
        BattleMovementObject.GetComponent<BattleMovement>().NormalMove();

    }
    public void PlayerEffects()
    {
        
    }
    public void ResetTurn()
    {
        

    }
    public void TakeDamage(int amount)
    {

        if(health <= 0 || health >= -1)
        {
            Debug.Log("Game Over");
            DeathScript.GetComponent<DeathTrigger>().DeathEventTrigger();
        }
        else
        health -= amount;
    }
   
}
