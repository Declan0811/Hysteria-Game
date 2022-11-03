using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    //Card
    public GameManager gameManager;
    public GameObject card;
    //UI icons
    public Image kingdomPublic;
    public Image kingdomReligion;
    public Image kingdomHysteria;
    public Image kingdomCourt;
    //UI impact icons
    public Image kingdomPublicImpact;
    public Image kingdomReligionImpact;
    public Image kingdomHysteriaImpact;
    public Image kingdomCourtImpact;
    void Update()
    {
        //UI icons
        kingdomPublic.fillAmount = (float) GameManager.kingdomPublic / GameManager.maxValue;
        kingdomReligion.fillAmount = (float) GameManager.kingdomReligion / GameManager.maxValue;
        kingdomHysteria.fillAmount = (float) GameManager.kingdomHysteria / GameManager.maxValue;
        kingdomCourt.fillAmount = (float) GameManager.kingdomCourt / GameManager.maxValue;

        //UI impact icon
        //Right
        if(gameManager.direction == "right")
        {
            if(gameManager.currentCard.kPublicRight!=0)
                kingdomPublicImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kReligionRight != 0)
                kingdomReligionImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kHysteriaRight != 0)
                kingdomHysteriaImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kCourtRight != 0)
                kingdomCourtImpact.transform.localScale = new Vector3(1, 1, 0);
            Debug.Log("1");
        }
        //left
        else if (gameManager.direction == "left")
        {
            if (gameManager.currentCard.kPublicLeft != 0)
                kingdomPublicImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kReligionLeft != 0)
                kingdomReligionImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kHysteriaLeft != 0)
                kingdomHysteriaImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kCourtLeft != 0)
                kingdomCourtImpact.transform.localScale = new Vector3(1, 1, 0);
            Debug.Log("2");
        }
        else
        {
            kingdomPublicImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomReligionImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomHysteriaImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomCourtImpact.transform.localScale = new Vector3(0, 0, 0);
            Debug.Log("3");
        }
    }
}
