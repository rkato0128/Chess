using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Constants.PieceType type;
    private int cardAmount = 0;
    private int cost;

    [SerializeField] private Button buttonIncrease;
    [SerializeField] private Button buttonDecrease;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardAmountText;
    [SerializeField] private TextMeshProUGUI cardCostText;

    [SerializeField] private GameObject cardBg_white;
    [SerializeField] private GameObject cardBg_black;
    [SerializeField] private Image pieceImage;
    [SerializeField] private Sprite[] pieceImgResources;


    private void Awake()
    {
        buttonIncrease.onClick.AddListener(Increase);
        buttonDecrease.onClick.AddListener(Decrease);

        cost = Constants.PieceCost[type];

        SetData(Constants.Team.WHITE);

        // Initialize Value
        cardName.text = type.ToString();
        cardAmountText.text = cardAmount.ToString();
        cardCostText.text = cost.ToString();
    }

    public void SetData(Constants.Team team)
    {
        // Set Piece Image : white 0~5 / black 6~11
        pieceImage.sprite = pieceImgResources[(int)type + 6 * (int)team];

        // Set Card Bg by team
        cardBg_white.SetActive(team == Constants.Team.WHITE ? true : false);
        cardBg_black.SetActive(team == Constants.Team.BLACK ? true : false);
    }

    private void Increase()
    {
        // check limit on DeckBuildingManager method
        if(DeckBuildingManager.deckManager.CheckIncreaseCard(type))
        {
            cardAmount++;
            cardAmountText.text = cardAmount.ToString();
            //Debug.Log(type.ToString() + " - cardAmount : " + cardAmount);
        }
    }

    private void Decrease()
    {
        // check card num is over 0
        if(cardAmount - 1 >= 0)
        {
            // check cost is under 0 on DeckBuildingManager method
            if(DeckBuildingManager.deckManager.CheckDecreaseCard(type))
            {
                cardAmount--;
                cardAmountText.text = cardAmount.ToString();
                //Debug.Log(type.ToString() + " - cardAmount : " + cardAmount);
            }
        }
    }
}
