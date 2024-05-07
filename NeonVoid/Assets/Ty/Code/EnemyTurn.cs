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


    public int randNum;
    public GameObject CurrentLocation;
    public Animator PlayerAni;
    public Animator EnemyAni;

    public bool isEnemyTurn;
    public bool hasTalked;
    public bool setAttack;

    //Player Attack Attributes
    public bool isAttack1;
    public int A1Damage = 1;

    public bool isAttack2;
    public int A2Damage = 3;

    public bool isAttack3;
    public int A3Damage = 4;

    public GameObject BottomPoint;
    public GameObject LowerLeftPoint;
    public GameObject UpperLeftPoint;
    public GameObject TopPoint;
    public GameObject UpperRightPoint;
    public GameObject LowerRightPoint;


    public GameObject PlayerHealth;
    Vector3 fwd;

    private void Start()
    {
        
    }


    private void Update()
    {
        if(isEnemyTurn == true && setAttack == false)
        {
            SelectAttack();
        }
        else if(isEnemyTurn == true && setAttack == true)
        {
            AttackEffect();
        }
    }

    public void AttackEffect()
    {

        if(isAttack1 == true)
        {
            if(CurrentLocation.GetComponent<DetectionScript>().BeingAttacked == true)
            {
                Player.GetComponent<PlayerStats>().TakeDamage(A1Damage);
                Debug.Log("HURT!");
                PlayerAni.SetTrigger("Hurt");
                PlayerHealth.GetComponent<HealthDisplay>().UpdateHealth();
            }

            BottomPoint.GetComponent<DetectionScript>().isAttacking = false;
            LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = false;
            UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = false;
            TopPoint.GetComponent<DetectionScript>().isAttacking = false;
            UpperRightPoint.GetComponent<DetectionScript>().isAttacking = false;
            LowerRightPoint.GetComponent<DetectionScript>().isAttacking = false;
            isAttack1 = false;
            isEnemyTurn = false;
            setAttack = false;
        }
        if (isAttack2 == true)
        {
            if (CurrentLocation.GetComponent<DetectionScript>().BeingAttacked == true)
            {
                Player.GetComponent<PlayerStats>().TakeDamage(A2Damage);
                Debug.Log("HURT!");
                PlayerAni.SetTrigger("Hurt");
                PlayerHealth.GetComponent<HealthDisplay>().UpdateHealth();
            }

            BottomPoint.GetComponent<DetectionScript>().isAttacking = false;
            LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = false;
            UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = false;
            TopPoint.GetComponent<DetectionScript>().isAttacking = false;
            UpperRightPoint.GetComponent<DetectionScript>().isAttacking = false;
            LowerRightPoint.GetComponent<DetectionScript>().isAttacking = false;
            isAttack2 = false;
            isEnemyTurn = false;
            setAttack = false;
        }
        if (isAttack3 == true)
        {
            if (CurrentLocation.GetComponent<DetectionScript>().BeingAttacked == true)
            {
                Player.GetComponent<PlayerStats>().TakeDamage(A3Damage);
                Debug.Log("HURT!");
                PlayerAni.SetTrigger("Hurt");
                PlayerHealth.GetComponent<HealthDisplay>().UpdateHealth();
            }

            BottomPoint.GetComponent<DetectionScript>().isAttacking = false;
            LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = false;
            UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = false;
            TopPoint.GetComponent<DetectionScript>().isAttacking = false;
            UpperRightPoint.GetComponent<DetectionScript>().isAttacking = false;
            LowerRightPoint.GetComponent<DetectionScript>().isAttacking = false;
            isAttack3 = false;
            isEnemyTurn = false;
            setAttack = false;
        }
    }

    public void SelectAttack()
    {
        randNum = Random.Range(0, 2);
        if (randNum == 0)
        {
            Debug.Log("ATTACK1");
            Attack1();
        }
        if (randNum == 1)
        {
            Debug.Log("ATTACK2");
            Attack2();
        }
        if (randNum == 2)
        {
            Debug.Log("ATTACK3");
        }
        isEnemyTurn = false;
    }

    public void Attack1()
    {
        CurrentLocation.GetComponent<DetectionScript>().isAttacking = true;
        setAttack = true;
        isAttack1 = true;
    }

    public void Attack2()
    {
        setAttack = true;
        isAttack2 = true;
        if (BottomPoint == CurrentLocation)
        {
            BottomPoint.GetComponent<DetectionScript>().isAttacking = true;
            LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
            LowerRightPoint.GetComponent<DetectionScript>().isAttacking = true;
            Debug.Log("Bottom");
        }
        if (LowerLeftPoint == CurrentLocation)
        {
            LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
            BottomPoint.GetComponent<DetectionScript>().isAttacking = true;
            UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
            Debug.Log("LowerLeft");
        }
        if(UpperLeftPoint == CurrentLocation)
        {
            UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
            LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
            TopPoint.GetComponent<DetectionScript>().isAttacking = true;
            Debug.Log("UpperLeft");
        }
        if (TopPoint == CurrentLocation)
        {
            TopPoint.GetComponent<DetectionScript>().isAttacking = true;
            UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
            UpperRightPoint.GetComponent<DetectionScript>().isAttacking = true;
            Debug.Log("Top");
        }
        if (UpperRightPoint == CurrentLocation)
        {
            UpperRightPoint.GetComponent<DetectionScript>().isAttacking = true;
            TopPoint.GetComponent<DetectionScript>().isAttacking = true;
            LowerRightPoint.GetComponent<DetectionScript>().isAttacking = true;
            Debug.Log("UpperRight");
        }
        if (LowerRightPoint == CurrentLocation)
        {
            LowerRightPoint.GetComponent<DetectionScript>().isAttacking = true;
            UpperRightPoint.GetComponent<DetectionScript>().isAttacking = true;
            BottomPoint.GetComponent<DetectionScript>().isAttacking = true;
            Debug.Log("LowerRight");
        }
    }

    public void Attack3()
    {
        TopPoint.GetComponent<DetectionScript>().isAttacking = true;
        UpperRightPoint.GetComponent<DetectionScript>().isAttacking = true;
        LowerRightPoint.GetComponent<DetectionScript>().isAttacking = true;
        BottomPoint.GetComponent<DetectionScript>().isAttacking = true;
        LowerLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
        UpperLeftPoint.GetComponent<DetectionScript>().isAttacking = true;
        setAttack = true;
        isAttack3 = true;
    }

}


