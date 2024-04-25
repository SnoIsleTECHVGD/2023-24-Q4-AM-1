using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CardUI : MonoBehaviour
{
    public CardCode cards;
    public TMP_Text cardDescription;
    public Image CardImage;
    BattleCode battleCode;
    public void SelectCard()
    {
        
        battleCode.selectedCard = this;
    }
    public void LoadCard(CardCode _cards)
    {
        
        cards = _cards;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        cardDescription.text = cards.cardDescription;
        CardImage.sprite = cards.CardIcon;
  }
}
