using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRewards : MonoBehaviour
{
    GameManager gameManager;
    public Image cardRewardIMG;
   public void displayThree(CardCode c)
    {
        cardRewardIMG.sprite = c.CardIcon;
        
    }
}
