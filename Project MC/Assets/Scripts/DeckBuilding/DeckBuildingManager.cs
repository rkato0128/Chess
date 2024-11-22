using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckBuildingManager : MonoBehaviour
{
    // Singleton
    private static DeckBuildingManager _deckManager = null;
    
    private void Awake()
    {
        if(_deckManager == null)
        {
            _deckManager = this;
        }
    }

    public static DeckBuildingManager deckManager
    {
        get
        {
            if(_deckManager == null)
            {
                return null;
            }
            return _deckManager;
        }
    }


    [SerializeField] private TextMeshProUGUI currentCostText;

    [SerializeField] private float deckMaxCost = 10;
    private float currentCost = 0;



    private void Start()
    {
        UpdateCostText();
    }

    // check condition and increase cost / return boolean
    public bool CheckIncreaseCost(int cost)
    {
        if(currentCost + cost <= deckMaxCost)
        {
            currentCost += cost;
            UpdateCostText();
            Debug.Log("Cost Increased to : " + currentCost);

            return true;
        }
        else
        {
            return false;
        }
    }

    // check condition and decrease cost / return boolean
    public bool CheckDecreaseCost(int cost)
    {
        if(currentCost - cost >= 0)
        {
            currentCost -= cost;
            UpdateCostText();
            Debug.Log("Cost Decreased to : " + currentCost);

            return true;
        }
        else
        {
            return false;
        }
    }

    // Update Cost Text
    private void UpdateCostText()
    {
        currentCostText.text = currentCost + " / " + deckMaxCost;
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
