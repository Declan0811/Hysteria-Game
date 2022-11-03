using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu] 
public class Card: ScriptableObject
{
    //Basic card values
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;
    //impact values
    public int kPublicLeft;
    public int kReligionLeft;
    public int kHysteriaLeft;
    public int kCourtLeft;
    //Right
    public int kPublicRight;
    public int kReligionRight;
    public int kHysteriaRight;
    public int kCourtRight;
    public void Left()
    {
        Debug.Log(cardName + " swiped left");
        //Appending the values
        GameManager.kingdomPublic += kPublicLeft;
        GameManager.kingdomReligion += kReligionLeft;
        GameManager.kingdomHysteria += kHysteriaLeft;
        GameManager.kingdomCourt += kCourtLeft;

    }
    public void Right()
    {
        Debug.Log(cardName + " swiped right");
        //Appending the values
        GameManager.kingdomPublic += kPublicRight;
        GameManager.kingdomReligion += kReligionRight;
        GameManager.kingdomHysteria += kHysteriaRight;
        GameManager.kingdomCourt += kCourtRight;
    }

}
