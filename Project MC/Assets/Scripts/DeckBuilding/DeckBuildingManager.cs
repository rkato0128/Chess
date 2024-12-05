using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

        UpdateCostText();
        buttonSaveDeck.onClick.AddListener(CompleteBuilding);
        
        whiteTurnObj.SetActive(true);
        blackTurnObj.SetActive(false);
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
    [SerializeField] private Button buttonSaveDeck;
    [SerializeField] private GameObject whiteTurnObj;
    [SerializeField] private GameObject blackTurnObj;

    [SerializeField] private float deckMaxCost = 10;
    private float currentCost = 0;

    private int[] deckData = new int[5];


    // check condition and increase cost / return boolean
    public bool CheckIncreaseCard(Constants.PieceType type)
    {
        if(currentCost + Constants.PieceCost[type] <= deckMaxCost)
        {
            currentCost += Constants.PieceCost[type];
            deckData[(int)type]++;

            UpdateCostText();
            //Debug.Log("Cost Increased to : " + currentCost);

            return true;
        }
        else
        {
            return false;
        }
    }

    // check condition and decrease cost / return boolean
    public bool CheckDecreaseCard(Constants.PieceType type)
    {
        if(currentCost - Constants.PieceCost[type] >= 0)
        {
            currentCost -= Constants.PieceCost[type];
            deckData[(int)type]--;

            UpdateCostText();
            //Debug.Log("Cost Decreased to : " + currentCost);

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


    // Deck Save and Load Play Scene
    private void SaveDeckData(Constants.Team team)
    {
        string temp = team.ToString();

        // Save Data on PlayerPrefs
        for(int i = 0; i < deckData.Length; ++i)
        {
            // key = teamEnum_PieceEnum : value
            string key = ((int)team).ToString() + "_" + i.ToString();
            PlayerPrefs.SetInt(key, deckData[i]);

            Debug.Log("Save Deck Data : " + key + " : " + deckData[i]);
        }
    }

    private bool isCompleteBuilding = false;

    // Check Deck Save Phase and Change Scene
    private void CompleteBuilding()
    {
        if(!isCompleteBuilding)
        {
            SaveDeckData(Constants.Team.WHITE);
            
            whiteTurnObj.SetActive(false);
            blackTurnObj.SetActive(true);

            isCompleteBuilding = true;
        }
        else
        {
            SaveDeckData(Constants.Team.BLACK);
            SceneManager.LoadScene("Play");
        }
    }
}
