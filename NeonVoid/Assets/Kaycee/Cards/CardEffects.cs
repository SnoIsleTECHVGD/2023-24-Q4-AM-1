using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    public CardCode cardCode;
    BattleCode battleCode;
    public PlayerStats playerStats;
    GameManager gameManager;
    public EnemyStats enemyStats;
    public Animator EnemyAni;
    public Animator PlayerAni;
    
    private void Awake()
    {
        battleCode = FindObjectOfType<BattleCode>();
        playerStats = FindObjectOfType<PlayerStats>();
        enemyStats = FindObjectOfType<EnemyStats>();
    }
    public void AvailableActions(CardCode _cardCode, PlayerStats _playerStats, EnemyStats _enemyStats)
    {
        cardCode = _cardCode;
        Debug.Log("Made it here");
        playerStats = _playerStats;
        enemyStats = _enemyStats;
        Debug.Log("card is being recognized");
        switch (cardCode.cardName)
        {
            
            
            case "Denim Dodge":
                MovePlayer();
                break;
            case "Emo Chomp":
                DamageEnemy();
                break;
            case "Galaxy Shield":
                GiveBuff();
                break;
            case "Gangam Style":
                break;
            case "Glitch":
                MovePlayer();
                break;
            case "Learning Algorithm":
                GiveBuff();
                break;
            case "Slap":
                DamageEnemy();
                break;
            case "Stun Dipper":
                DamageEnemy();
                MovePlayer();
                break;
            case "Threadripper":
                SpecialCase();
                break;
                    case "Thread":
                DamageEnemy();
                break;
                

                


        }
    }
    public void DamageEnemy()
    {
        int DmgEnemy = cardCode.damage;
        enemyStats.TakeDMG(DmgEnemy);
        PlayerAni.SetTrigger("Attack");
        EnemyAni.SetTrigger("Hurt");
        Debug.Log("Attacks and Hurt");
    }
    public void MovePlayer()
    {
        playerStats.MovePlayer();
    }
    public void GiveBuff()
    {
        playerStats.PlayerEffects();
    }
    public void SpecialCase()
    {
        battleCode.GetComponent<BattleCode>().cardsInHand.Add(gameManager.cardLibrary[1]);
        battleCode.GetComponent<BattleCode>().cardsInHand.Add(gameManager.cardLibrary[1]);
        battleCode.GetComponent<BattleCode>().cardsInHand.Add(gameManager.cardLibrary[1]);
    }
  
}
