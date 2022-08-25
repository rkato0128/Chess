using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckBuildingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentCostText;

    [SerializeField] private float deckMaxCost = 5;
    private float deckCost;

    private string costString;


    public void IncreaseCost()
    {

    }

    private void SaveDeckData(Constants.Team team)
    {
        string temp = team.ToString();

        // Save Data on PlayerPrefs
    }

    // Prototype
    private void CompleteBuilding()
    {

    }
}
