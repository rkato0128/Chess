using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup : MonoBehaviour
{
    public Constants.Team team;

    public List<Card_Play> cardSet;

    [SerializeField] private GameObject Card;

    private void Start()
    {

    }

    public void LoadDeckDataToCardSet()
    {
        string temp = team.ToString();

        // Load Data on PlayerPrefs
        for(int i = 0; i < 5; ++i)
        {
            // key = teamEnum_PieceEnum : value
            string key = ((int)team).ToString() + "_" + i.ToString();
            int count = PlayerPrefs.GetInt(key);

            for(int j = 0; j < count; ++j)
            {
                InstantiateCard((Constants.PieceType) i, team);
            }

            Debug.Log("Load Deck Data : " + key);
        }

        // Add King
        InstantiateCard(Constants.PieceType.KING, team);
    }

    private void InstantiateCard(Constants.PieceType pieceType, Constants.Team teamType)
    {
        GameObject card = Instantiate(Card);

        card.transform.SetParent(this.gameObject.transform);
        card.GetComponent<Card_Play>().SetData(pieceType, teamType);

        cardSet.Add(card.GetComponent<Card_Play>());
    }
}
