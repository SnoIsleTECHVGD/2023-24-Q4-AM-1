using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour
{
    public GameObject EnergyOne;
    public GameObject EnergyTwo;
    public GameObject EnergyThree;
    public GameObject EnergyTemp;

    public GameObject BattleSystem;


    public int EnergyNumber;

    // Update is called once per frame
    void Update()
    {
        EnergyNumber = BattleSystem.GetComponent<BattleCode>().energy;



        if(EnergyNumber == 3)
        {
            EnergyOne.SetActive(true);
            EnergyTwo.SetActive(true);
            EnergyThree.SetActive(true);
            
        }
        else if(EnergyNumber == 2)
        {
            EnergyOne.SetActive(true);
            EnergyTwo.SetActive(true);
            EnergyThree.SetActive(false);
        }
        else if (EnergyNumber == 1)
        {
            EnergyOne.SetActive(true);
            EnergyTwo.SetActive(false);
            EnergyThree.SetActive(false);
        }
        else if (EnergyNumber == 0)
        {
            EnergyOne.SetActive(false);
            EnergyTwo.SetActive(false);
            EnergyThree.SetActive(false);
        }
    }
}
