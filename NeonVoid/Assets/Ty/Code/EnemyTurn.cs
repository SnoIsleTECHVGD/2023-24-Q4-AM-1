using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    public GameObject Raycastobject;

    public float MaxDistance;
    public int Loading;
    public GameObject Enemy;
    public GameObject Player;
    public RaycastHit hit;
    public Ray ray;
    public bool isEnemyTurn;
    public int randNum;
    public GameObject[] LocationPoints;
    public GameObject CurrentLocation;

    Vector3 fwd;

    private void Start()
    {
        
    }


    private void Update()
    {
        if(isEnemyTurn == true)
        {
            SelectAttack();
        }
        
    }

    public void SelectAttack()
    {
        randNum = Random.Range(0, 4);
        if(randNum == 0)
        {
            Debug.Log("ATTACK1");
            Attack1();
        }
        if (randNum == 1)
        {
            Debug.Log("ATTACK2");
        }
        if (randNum == 2)
        {
            Debug.Log("ATTACK3");
        }
        if (randNum == 3)
        {
            Debug.Log("How's the weather?");
        }
        isEnemyTurn = false;
    }


    public void Attack1()
    {
        CurrentLocation.GetComponent<DetectionScript>().isAttacking = true;
    }
}


