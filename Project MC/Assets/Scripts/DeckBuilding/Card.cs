using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Constants.PieceType type;

    [SerializeField] private Button buttonIncrease;
    [SerializeField] private Button buttonDecrease;


    private void Awake()
    {
        buttonIncrease.onClick.AddListener(Increase);
        buttonDecrease.onClick.AddListener(Decrease);
    }

    private void Increase()
    {

    }

    private void Decrease()
    {

    }
}
