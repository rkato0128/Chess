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

    [SerializeField] private Image turnImg;

    public void ChangeTurnImg(Constants.Team team)
    {
        switch (team)
        {
            case Constants.Team.WHITE :
                turnImg.color = Color.white;
                break;

            case Constants.Team.BLACK :
                turnImg.color = Color.black;
                break;
        }
    }
}
