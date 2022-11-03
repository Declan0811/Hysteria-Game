using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card card;
    public BoxCollider2D thisCard;
    public bool isMouseOver;
    public void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }
    public void OnMouseOver()
    {
        isMouseOver = true;
    }
    public void OnMouseExit()
    {
        isMouseOver = false;
    }
   
}



public enum CardSprite
{
    Executioner,
    Putnam,
    Marshal,
    Judge,
    Homeless,
    Servant,
    Priest,
    Farmer,
    Headgirl,
    Goodwife,
}
