using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // 싱글톤
    public static BoardManager boardManager;
    
    private void Awake()
    {
        boardManager = this;
    }

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
            pieceObject.GetComponent<ChessPiece>().Set(Constants.Team.WHITE, board[0,0]); // for test
        }
    }

    void GenerateBoard()
    {
        bool isBlack = true;

        // y : Column (A,B,C...) / x : Row (1,2,3...)
        for(int y = 0; y < 6; y++)
        {
            for(int x = 0; x < 6; x++)
            {
                GameObject tile;
                tile = Instantiate(boardTile, new Vector3(tileSize * x, 0, tileSize * y), Quaternion.identity);

                board[x ,y] = tile.GetComponent<BoardTile>();
                board[x ,y].SetTile(x, y, isBlack);

                tile.name = (char) (65 + x) + (y + 1).ToString();
                tile.transform.SetParent(this.gameObject.transform);

                isBlack = isBlack ? false : true;
            }

            isBlack = isBlack ? false : true;
        }
    }


    // Checking Space    
    public List<BoardTile> moveableArea = new List<BoardTile>();

    public void CheckPiecePath(ChessPiece piece)
    {
        moveableArea.Clear();

        switch (piece.type)
        {
            case Constants.UnitType.PAWN :
                CheckPawnPath(piece.currentTile.column, piece.currentTile.row, piece.team);
                break;

            case Constants.UnitType.ROOK :
                break;

            case Constants.UnitType.KNIGHT :
                break;
            
            case Constants.UnitType.BISHOP :
                break;
            
            case Constants.UnitType.QUEEN :
                break;
            
            case Constants.UnitType.KING :
                break;
        }

        PrintMoveableArea();
    }

    private void CheckPawnPath(int pieceColumn, int pieceRow, Constants.Team team, bool isFirstMove = false)
    {
        int movingDir = (team == Constants.Team.WHITE) ? 1 : -1;

        if(isFirstMove)
        {
            CheckGeneralMovement(team, pieceColumn, pieceRow, 0, movingDir, 2);
        }
        else
        {
            CheckGeneralMovement(team, pieceColumn, pieceRow, 0, movingDir);
        }
    }

    // movingDir 값 -1, 0, 1 로 한정짓고 싶을 때 clamp?
    private void CheckGeneralMovement(Constants.Team team, int pieceColumn, int pieceRow, int movingDirX, int movingDirY, int moveCount = 1)
    {
        int checkX = pieceColumn;
        int checkY = pieceRow;

        int count = 1;

        while(true)
        {
            if(checkX < 0 || checkX > 5 || checkY < 0 || checkY > 5 || count > moveCount)
            {
                break;
            }

            checkX += 1 * movingDirX;
            checkY += 1 * movingDirY;

            if(board[checkX, checkY].isPieceOnTile)
            {
                if(board[checkX, checkY].pieceOnTile.team != team)
                {
                    moveableArea.Add(board[checkX, checkY]);
                }

                break;
            }
            else
            {
                moveableArea.Add(board[checkX, checkY]);
            }

            count++;
        }
    }

    private void PrintMoveableArea()
    {
        foreach(BoardTile tile in moveableArea)
        {
            tile.Moveable();
        }
    }
}