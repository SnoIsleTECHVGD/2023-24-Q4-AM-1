using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardRewards : MonoBehaviour
{
    GameManager gameManager;
    public Image cardRewardIMG;
    public TMP_Text cardDescription;
   public void displayThree(CardCode c)
    {
        cardRewardIMG.sprite = c.CardIcon;
        cardDescription.text = c.cardDescription;
        
    }
}
