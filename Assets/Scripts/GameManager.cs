using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Gameobjects
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    //Tweaking variables
    public float fMovingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    float alphaText;
    public Color textColor;
    Vector3 pos;
    //UI
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    //Card variables
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    void Start()
    {
        LoadCard(testCard);  
    }

    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else
        {
            actionQuote.text = rightQuote;
        }
    }

    void Update()
    {
        //Dialogue text handling
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
            }
        }
        else if (cardGameObject.transform.position.x > fSideMargin)
        {

        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {

        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        UpdateDialogue();
        //movement
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 1), fMovingSpeed);
        }
        //UI
        display.text = "" + textColor.a;
    }
        

    void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;
    }

    public void NewCard()
    {
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }
}
