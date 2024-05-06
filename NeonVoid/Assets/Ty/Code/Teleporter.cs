using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public Transform ExitPoint;

    public float TimeTillAgain;

    public bool CanGo;


    public void OnTriggerEnter(Collider other)
    {
        if(CanGo == true)
        {
            Player.transform.position = ExitPoint.position;
            CanGo = false;
            Invoke("ActivateGo", TimeTillAgain);
        }
    }


    public void ActivateGo()
    {
        CanGo = true;
    }
}
