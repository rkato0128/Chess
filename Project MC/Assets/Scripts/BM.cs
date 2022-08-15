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

    // Board Manager
    public Vector2Int size = new Vector2Int(6, 6);
    [System.NonSerialized] public BoardTile[,] board;
    public GameObject[] chessPieces;

    [Space]
    [SerializeField] private GameObject boardTile;
    [SerializeField] private float tileSize = 1;

    public enum TurnState
    {
        NONE,
        PIECESELECT
    }

    public TurnState currentTurnState;


    private void Start()
    {
        board = new BoardTile[size.x, size.y];
        GenerateBoard();

        currentTurnState = TurnState.NONE;

        // 배치 데이터 넘겨받아서 보드에 배치 / 테스트용
        int i = 0;
        foreach (GameObject pieceObject in chessPieces)
        {
            pieceObject.GetComponent<ChessPiece>().Set(board[i, 0]); // for test
            i++;
        }
    }

    private void GenerateBoard()
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

    // Handling Raycast interaction
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast Hit : " + hit.transform.gameObject.name);
                Interaction(hit);
            }
        }
    }

    private ChessPiece selectedPiece;
    private BoardTile selectedTile;

    private bool pieceSelected = false;

    private void Interaction(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent<ChessPiece>(out ChessPiece selected)) // Piece Click
        {
            if (pieceSelected)
            {
                ClearMoveableArea();
            }

            selectedPiece = selected;

            pieceSelected = true;
            //currentTurnState = TurnState.PIECESELECT;
            selectedPiece.CheckPath();

            PrintMoveableArea();

            Debug.Log("Chess Piece Selected - " + selectedPiece.gameObject.name);

            //Debug.Log("is Piece Same in Array" + selectedPiece.Equals(boardManager.chessPieces[0])); // 값이 다름? - 식별 인덱스 추가
        }
        else if (pieceSelected)
        {
            if (hit.transform.gameObject.TryGetComponent<BoardTile>(out BoardTile temptile)) // Tile Click
            {
                selectedTile = temptile;

                if (moveableArea.Contains(selectedTile))
                {
                    selectedPiece.Move(selectedTile);

                    pieceSelected = false;
                    //currentTurnState = TurnState.PIECESELECT;

                    ClearMoveableArea();

                    Debug.Log("Piece Moved to Tile " + selectedTile.gameObject.name);
                }
            }
        }

        // Null Reference Exception
        //if (hit.transform.gameObject.TryGetComponent<ChessPiece>(out selectedPiece)) // Piece Click
        //{
        //    if (pieceSelected)
        //    {
        //        ClearMoveableArea();
        //    }

        //    pieceSelected = true;
        //    //currentTurnState = TurnState.PIECESELECT;
        //    selectedPiece.CheckPath();

        //    PrintMoveableArea();

        //    Debug.Log("Chess Piece Selected - " + selectedPiece.gameObject.name);

        //    //Debug.Log("is Piece Same in Array" + selectedPiece.Equals(boardManager.chessPieces[0])); // 값이 다름? - 식별 인덱스 추가
        //}
        //else if (pieceSelected)
        //{
        //    if (hit.transform.gameObject.TryGetComponent<BoardTile>(out selectedTile)) // Tile Click
        //    {
        //        if (moveableArea.Contains(selectedTile))
        //        {
        //            selectedPiece.Move(selectedTile);

        //            pieceSelected = false;
        //            //currentTurnState = TurnState.PIECESELECT;

        //            ClearMoveableArea();

        //            Debug.Log("Piece Moved to Tile " + selectedTile.gameObject.name);
        //        }
        //    }
        //}
    }


    // Checking Space
    public List<BoardTile> moveableArea = new List<BoardTile>();

    //public List<BoardTile> moveableArea {get{return _moveableArea;}}

    //public void AddMoveableList(BoardTile tile)
    //{
    //    _moveableArea.Add(tile);
    //}

    // get 으로 가져온 List 에 Add() 가능?

    private void ClearMoveableArea()
    {
        foreach(BoardTile tile in moveableArea)
        {
            tile.SetTileOriginColor();
        }

        moveableArea.Clear();
    }

    public void PrintMoveableArea()
    {
        foreach(BoardTile tile in moveableArea)
        {
            tile.Moveable();
        }
    }
}