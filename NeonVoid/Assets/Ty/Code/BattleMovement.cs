using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMovement : MonoBehaviour
{
    public int randNumber;
    public GameObject BottomPoint;
    public GameObject LowerLeftPoint;
    public GameObject UpperLeftPoint;
    public GameObject TopPoint;
    public GameObject UpperRightPoint;
    public GameObject LowerRightPoint;

    public GameObject CurrentLocation;

    public GameObject Player;

    public void Glitch()
    {
        randNumber = Random.Range(0, 5);
        if(randNumber == 0)
        {
            Player.transform.position = BottomPoint.transform.position;
        }
        if (randNumber == 1)
        {
            Player.transform.position = LowerLeftPoint.transform.position;
        }
        if (randNumber == 2)
        {
            Player.transform.position = UpperLeftPoint.transform.position;
        }
        if (randNumber == 3)
        {
            Player.transform.position = TopPoint.transform.position;
        }
        if (randNumber == 4)
        {
            Player.transform.position = UpperRightPoint.transform.position;
        }
        if (randNumber == 5)
        {
            Player.transform.position = LowerRightPoint.transform.position;
        }
    }

    public void NormalMove()
    {

        if(CurrentLocation == BottomPoint)
        {
            Player.transform.position = LowerLeftPoint.transform.position;
        }
        else if (CurrentLocation == LowerLeftPoint)
        {
            Player.transform.position = UpperLeftPoint.transform.position;
        }
        else if (CurrentLocation == UpperLeftPoint)
        {
            Player.transform.position = TopPoint.transform.position;
        }
        else if (CurrentLocation == TopPoint)
        {
            Player.transform.position = UpperRightPoint.transform.position;
        }
        else if (CurrentLocation == UpperRightPoint)
        {
            Player.transform.position = LowerRightPoint.transform.position;
        }
        else if (CurrentLocation == LowerRightPoint)
        {
            Player.transform.position = BottomPoint.transform.position;
        }
    }
}
