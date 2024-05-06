using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CardCode> playerDeck = new List<CardCode>();
    public List<CardCode> cardLibrary = new List<CardCode>();
    public List<CardCode> cardRewards = new List<CardCode>();
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
