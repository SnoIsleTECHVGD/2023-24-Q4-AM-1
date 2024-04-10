using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health, sunnyD, shield, overHeat, electrified, overHeatStorage, electrifiedStorage, sunnyDMax, overCharge;
    public string[] barkTextPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerEffects()
    {

    }
    public void ResetTurn()
    {
        sunnyD = sunnyDMax;
        if(overCharge > 0)
        {
            sunnyD = sunnyD + overCharge;
        }

    }
   
}
