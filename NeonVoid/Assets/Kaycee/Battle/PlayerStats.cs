using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health, overHeat, electrified, overHeatStorage, electrifiedStorage, moveAmount;
    public string[] barkTextPlayer;

    public GameObject DeathScript;

    public GameObject BattleMovementObject;

    public GameObject HealthObj;

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
        
            health -= amount;
        HealthObj.GetComponent<HealthDisplay>().healthAmount = health;
        if (health <= 0)
        {
            Debug.Log("Game Over");
            DeathScript.GetComponent<DeathTrigger>().DeathEvent.Invoke();
        }
        
        
    }
   
}
