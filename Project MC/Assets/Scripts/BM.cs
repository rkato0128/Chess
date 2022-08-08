using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM : MonoBehaviour
{
    // Singletone
    private static BM _boardManager = null;
    
    private void Awake()
    {
        if(_boardManager == null)
        {
            _boardManager = this;
        }
    }

    public static BM boardManager
    {
        get
        {
            if(_boardManager == null)
            {
                return null;
            }
            return _boardManager;
        }
    }


    public Vector2Int size = new Vector2Int(6, 6);
    [System.NonSerialized] public BoardTile[,] board;
    public GameObject[] chessPieces;

    [Space]
    [SerializeField] private GameObject boardTile;
    [SerializeField] private float tileSize = 1;


    void Start()
    {
        board = new BoardTile[size.x, size.y];

        GenerateBoard();

        // 배치 데이터 넘겨받아서 보드에 배치
        foreach(GameObject pieceObject in chessPieces)
        {
            pieceObject.GetComponent<ChessPiece>().Set(board[0,0]); // for test
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

    public void ClearMoveableArea()
    {
        moveableArea.Clear();
    }

    public void PrintPath()
    {
        PrintMoveableArea();
    }

    public void PrintMoveableArea() // protection level error
    {
        foreach(BoardTile tile in moveableArea)
        {
            tile.Moveable();
        }
    }
}