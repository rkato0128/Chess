using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    [HideInInspector] public Vector3[,] board = new Vector3[6,6];

    //public BoardTile[,] board = new BoardTile[6,6];

    [SerializeField] private GameObject tileWhite;
    [SerializeField] private GameObject tileBlack;
    [SerializeField] private float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        bool isBlack = true;

        for(int i = 0; i < 6; i++) // j - Horizontal (A,B,C...) / i = Vertical (1,2,3...)
        {
            for(int j = 0; j < 6; j++)
            {
                board[j ,i] = new Vector3(tileSize * j, 0, tileSize * i);
                
                GameObject tile;

                if(isBlack)
                {
                    tile = Instantiate(tileBlack, board[j,i], Quaternion.identity);
                    isBlack = false;
                }
                else
                {
                    tile = Instantiate(tileWhite, board[j,i], Quaternion.identity);
                    isBlack = true;
                }

                tile.name = (char) (65 + j) + (i + 1).ToString();
                tile.transform.SetParent(this.gameObject.transform);

                //Debug.Log("is " + tile.name + " black? - " + isBlack);
            }

            isBlack = isBlack ? false : true;
        }
    }
}