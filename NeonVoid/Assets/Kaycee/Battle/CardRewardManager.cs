using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRewardManager : MonoBehaviour
{
    GameManager gameManager;
    public List<CardRewards> RewardsHolder;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void RandomizedCards()
    {
        gameManager.cardLibrary.Shuffle();
        for (int i = 0;i < 3;i++)
        {
            RewardsHolder[i].gameObject.SetActive(true);
            RewardsHolder[1].displayThree(gameManager.cardLibrary[i]);
        }
    }
    public void SelectedCard(int cardIndex)
    {
        gameManager.playerDeck.Add(gameManager.cardLibrary[cardIndex]);
        gameManager.cardLibrary.Remove(gameManager.cardLibrary[cardIndex]);

        for (int i = 0; i < 3; i++)
            RewardsHolder[i].gameObject.SetActive(false);

    }
  
}
