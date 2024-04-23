using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Template", menuName = "Card")]

public class CardCode : ScriptableObject
{
    //Constructor!! lmk if you may have questions on how this should function, how im going to yk set it up is going to be uh intresting to say the least :3
    
    #region Assests bools and refs
    public string cardName,cardDescription;
    public bool power, attack, skill, movement, specialCase, fleeting, inflictStatus, Common, Rare, Legendary;
    public Sprite CardIcon;
    public bool overHeat, electrified, block, overCharge, Vulnerable;
    public int damage, moveAmount, cost, inflictNum;
    #endregion

   

}
