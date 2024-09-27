using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Constants.PieceType type;
    public int cardAmount = 0;

    [SerializeField] private Button buttonIncrease;
    [SerializeField] private Button buttonDecrease;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardAmountText;


    private void Awake()
    {
        buttonIncrease.onClick.AddListener(Increase);
        buttonDecrease.onClick.AddListener(Decrease);

        // Initialize Value
        cardName.text = type.ToString();
        cardAmountText.text = cardAmount.ToString();
    }

    private void Increase()
    {
        // Max 값 가져와서 limit 처리 
        cardAmount++;
    }

    private void Decrease()
    {
        // 0 이하로 못 내려가도록 처리 
        cardAmount--;
    }
}
