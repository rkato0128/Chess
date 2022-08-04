using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //[HideInInspector] public Vector3[,] board = new Vector3[6,6];

    public BoardTile[,] board = new BoardTile[6,6];

    public GameObject[] chessPieces;

    [Space]

    [SerializeField] private GameObject boardTile;
    [SerializeField] private float tileSize = 1;


    void Start()
    {
        GenerateBoard();

        // 배치 데이터 넘겨받아서 보드에 배치
        foreach(GameObject pieceObject in chessPieces)
        {
            pieceObject.GetComponent<ChessPiece>().currentTile = board[0,0]; // for test
        }
    }

    void GenerateBoard()
    {
        bool isBlack = true;

        for(int i = 0; i < 6; i++) // j - Horizontal (A,B,C...) / i = Vertical (1,2,3...)
        {
            for(int j = 0; j < 6; j++)
            {
                GameObject tile;
                tile = Instantiate(boardTile, new Vector3(tileSize * j, 0, tileSize * i), Quaternion.identity);
                tile.GetComponent<BoardTile>().SetTileColor(isBlack);

                isBlack = isBlack ? false : true;

                tile.name = (char) (65 + j) + (i + 1).ToString();
                tile.transform.SetParent(this.gameObject.transform);
                
                board[j ,i] = tile.GetComponent<BoardTile>();

                //Debug.Log("is " + tile.name + " black? - " + isBlack);
            }

            isBlack = isBlack ? false : true;
        }
    }

    void CheckMoveablePath(ChessPiece piece) // Pawn
    {
        int pieceRow;
        int pieceColumn;

        List<BoardTile> moveablePath = new List<BoardTile>();

        pieceRow = 0; // test value
        pieceColumn = 0; // test value

        int MoveableTileCount = 2;

        for(int i = pieceColumn + 1; i < pieceColumn + 1 + MoveableTileCount; i++)
        {
            bool isUnitOnTile = board[pieceRow, i].isUnitOnTile;

            if(!isUnitOnTile)
            {
                moveablePath.Add(board[pieceRow, i]);
            }
        }
    }

    void MovePiece()
    {

    }
}