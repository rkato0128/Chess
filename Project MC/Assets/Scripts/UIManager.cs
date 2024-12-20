using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _UIManager = null;

    private void Awake()
    {
        if (_UIManager == null)
        {
            _UIManager = this;
        }
    }

    public static UIManager uiManager
    {
        get
        {
            if (_UIManager == null)
            {
                return null;
            }
            return _UIManager;
        }
    }


    [SerializeField] private GameObject turnWhite;
    [SerializeField] private GameObject turnBlack;
    [SerializeField] private GameObject winUI_White;
    [SerializeField] private GameObject winUI_Black;

    public void ChangeTurnImg(Constants.Team team)
    {
        turnWhite.SetActive(team == Constants.Team.WHITE ? true : false);
        turnBlack.SetActive(team == Constants.Team.BLACK ? true : false);
    }

    public void PrintWin(Constants.Team team)
    {
        // Print Win UI
        winUI_White.SetActive(team == Constants.Team.WHITE ? true : false);
        winUI_Black.SetActive(team == Constants.Team.BLACK ? true : false);
    }
}
