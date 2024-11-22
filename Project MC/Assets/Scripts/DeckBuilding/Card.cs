using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Constants.PieceType type;
    public int cardAmount = 0;
    private int cost;

    [SerializeField] private Button buttonIncrease;
    [SerializeField] private Button buttonDecrease;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardAmountText;
    [SerializeField] private TextMeshProUGUI cardCostText;


    private void Awake()
    {
        buttonIncrease.onClick.AddListener(Increase);
        buttonDecrease.onClick.AddListener(Decrease);

        cost = Constants.PieceCost[type];

        // Initialize Value
        cardName.text = type.ToString();
        cardAmountText.text = cardAmount.ToString();
        cardCostText.text = "Cost " + cost.ToString();
    }

    private void Increase()
    {
        // check limit on DeckBuildingManager method
        if(DeckBuildingManager.deckManager.CheckIncreaseCost(cost))
        {
            cardAmount++;
            cardAmountText.text = cardAmount.ToString();
            Debug.Log(type.ToString() + " - cardAmount : " + cardAmount);
        }
    }

    private void Decrease()
    {
        // check card num is over 0
        if(cardAmount - 1 >= 0)
        {
            // check cost is under 0 on DeckBuildingManager method
            if(DeckBuildingManager.deckManager.CheckDecreaseCost(cost) && (cardAmount - 1) >= 0)
            {
                cardAmount--;
                cardAmountText.text = cardAmount.ToString();
                Debug.Log(type.ToString() + " - cardAmount : " + cardAmount);
            }
        }
    }
}
