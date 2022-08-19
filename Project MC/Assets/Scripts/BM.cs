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

    public Constants.Team currentTeamTurn;

    [Space]
    [SerializeField] private GameObject boardTile;
    [SerializeField] private float tileSize = 1;


    private void Start()
    {
        board = new BoardTile[size.x, size.y];
        GenerateBoard();

        currentTeamTurn = Constants.Team.WHITE;

        // 배치 데이터 넘겨받아서 보드에 배치 / 테스트용
        int i = 0;

        foreach (GameObject pieceObject in chessPieces)
        {
            pieceObject.GetComponent<ChessPiece>().Set(board[i, 0]);
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


    // Game State
    private void ChangeTurn()
    {
        currentTeamTurn = currentTeamTurn == Constants.Team.WHITE ? Constants.Team.BLACK : Constants.Team.WHITE;
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

    private bool pieceSelectedState = false;

    private void Interaction(RaycastHit hit)
    {
        if (hit.transform.gameObject.GetComponent<ChessPiece>()) // Piece Click
        {
            hit.transform.gameObject.TryGetComponent<ChessPiece>(out selectedPiece);

            // 현재 팀 순서 체크
            if (selectedPiece.team == currentTeamTurn)
            {
                if (pieceSelectedState)
                {
                    ClearMoveableArea();
                }

                pieceSelectedState = true;
                selectedPiece.CheckPath();

                PrintMoveableArea();
            }
            else
            {
                // 현재 선택한 말이 공격 가능한 말인지 체크
            }

            Debug.Log("Chess Piece Selected - " + selectedPiece.gameObject.name);

            //Debug.Log("is Piece Same in Array" + selectedPiece.Equals(boardManager.chessPieces[0])); // 값이 다름? - 식별 인덱스 추가
        }
        else if (pieceSelectedState)
        {
            if (hit.transform.gameObject.TryGetComponent<BoardTile>(out selectedTile)) // Tile Click
            {
                if (moveableArea.Contains(selectedTile))
                {
                    selectedPiece.Move(selectedTile);
                    pieceSelectedState = false;
                    ClearMoveableArea();

                    Debug.Log("Piece Moved to Tile " + selectedTile.gameObject.name);
                }
            }
        }
    }


    // Checking Space
    private List<BoardTile> _moveableArea = new List<BoardTile>();
    public List<BoardTile> moveableArea { get { return _moveableArea; } } // get 으로 가져온 List 에 Add() 가능? - 가능


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