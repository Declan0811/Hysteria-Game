using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Gameobjects
    public GameObject cardGameObject;
    public GameObject pendingCardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public Vector2 defaultPositiionCard;
    public Vector3 cardRotation;
    //Tweaking variables
    public float fMovingSpeed;
    public float fRotatingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    public float backgroundDivideValue;
    float alphaText;
    public Color textColor;
    public Color actionBackgroundColor;  
    public float fTransparency = 0.7f;
    public float fRotationCoefficient;
    Vector3 pos;
    //UI
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    public SpriteRenderer actionBackground;
    //Card variables
    private string leftQuote;
    private string rightQuote;
    public Card testCard;
    public Card currentCard;
    //Substituting the card
  
    void Start()
    {
        LoadCard(testCard);  
    }

    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        actionBackground.color = actionBackgroundColor; 
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
        actionBackgroundColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / backgroundDivideValue, fTransparency);
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

        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositiionCard, fMovingSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);

        }
              cardGameObject.transform.position = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotatingSpeed);       
        //UI
        display.text = "" + textColor.a;

        characterDialogue.text = currentCard.dialogue;

        //Rotating the card
        cardGameObject.transform.position = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotatingSpeed);
    }
        

    public void LoadCard(Card card)
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
