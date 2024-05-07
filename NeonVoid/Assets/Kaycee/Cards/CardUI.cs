using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CardUI : MonoBehaviour
{
    //throw this code on each individual card "area" then make a child object which will be the parent of the individual aspects of the card, tmp for the discription, icon for the card so on so forth
    public CardCode cards;
    public TMP_Text cardDescription;
    public Image CardImage;
    BattleCode battleCode;
    private void Awake()
    {
        battleCode = FindObjectOfType<BattleCode>();
    }
        public void SelectCard()
    {
        
        battleCode.selectedCard = this;
    }
    public void LoadCard(CardCode _cards)
    {
        Debug.Log("attempting to load card");
        cards = _cards;
        
        cardDescription.text = cards.cardDescription;
        CardImage.sprite = cards.CardIcon;
  }
    public void PlayedCard()
    {
        if (battleCode.energy < cards.cost)
            return; // activate what happens after
            battleCode.PlayedCard(this);
    }
}
