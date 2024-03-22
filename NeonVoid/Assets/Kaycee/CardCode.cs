using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCode : ScriptableObject
{
    //Constructor!! lmk if you may have questions on how this should function, how im going to yk set it up is going to be uh intresting to say the least :3
    #region Assests bools and refs
    public string cardName;
    public bool power, attack, skill, movement, specialCase, fleeting, inflictStatus, Common, Rare, Legendary;
    public bool overHeat, electrified, block, overCharge;
    public int damage, moveAmount, cost, inflictNum;
    #endregion

    #region Constructor
    public CardCode(bool power, bool fleeting, bool attack, bool skill, bool movement, bool specialCase, bool inflictStatus, bool common, bool rare, bool legendary, bool overHeat, bool electrified, bool block, bool overCharge, int damage, int moveAmount, int cost, int inflictNum,string cardName)
    {
        this.power = power;
        this.fleeting = fleeting;
        this.attack = attack;
        this.skill = skill;
        this.movement = movement;
        this.specialCase = specialCase;
        this.inflictStatus = inflictStatus;
        Common = common;
        Rare = rare;
        Legendary = legendary;
        this.overHeat = overHeat;
        this.electrified = electrified;
        this.block = block;
        this.overCharge = overCharge;
        this.damage = damage;
        this.moveAmount = moveAmount;
        this.cost = cost;
        this.inflictNum = inflictNum;
        this.cardName = cardName;
    }
    #endregion

}
