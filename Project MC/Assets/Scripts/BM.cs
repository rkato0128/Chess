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

    public enum GamePhase
    {
        Deploy,
        Play
    }

    private GamePhase _currentPhase;
    public GamePhase currentPhase{ get { return _currentPhase; } }

    public bool isCardSelected = false; // check Deply phase status

    public GameObject[] chessPieceWhite;
    public GameObject[] chessPieceBlack;

    public Constants.Team currentTeamTurn;

    [Space]
    [SerializeField] private GameObject boardTile;
    [SerializeField] private float tileSize = 1;

    [Space]
    [SerializeField] private CardGroup cardGroup;


    private void Start()
    {
        board = new BoardTile[size.x, size.y];
        GenerateBoard();

        currentTeamTurn = Constants.Team.WHITE;

        // 배치 데이터 넘겨받아서 보드에 배치 / 테스트용
        _currentPhase = GamePhase.Play;
        // LoadDeckData(Constants.Team.WHITE); // Test
        // LoadDeckData(Constants.Team.BLACK); // Test

        int i = 0;

        foreach (GameObject pieceObject in chessPieceWhite)
        {
            pieceObject.GetComponent<ChessPiece>().Set(board[i, 0]);
            i++;
        }

        int j = 0;

        foreach (GameObject pieceObject in chessPieceBlack)
        {
            pieceObject.GetComponent<ChessPiece>().Set(board[j, 5]);
            j++;
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
    
    // Load Deck Data
    // private int[] deckData = new int[5];

    // void LoadDeckData(Constants.Team team)
    // {
    //     for(int i = 0; i < deckData.Length; ++i)
    //     {
    //         string key = ((int)team).ToString() + "_" + i.ToString();
    //         if(PlayerPrefs.HasKey(key))
    //         {
    //             deckData[i] = PlayerPrefs.GetInt(key);
    //             Debug.Log("Load Deck Data : " + key + " : " + deckData[i]);
    //         }
    //     }
    // }

    // Set Deck Hand
    private void SetHand()
    {
        cardGroup.team = currentTeamTurn;
        cardGroup.LoadDeckDataToCardSet();
    }
    


    // Handling Raycast interaction
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast Hit : " + hit.transform.gameObject.name);

                switch (currentPhase)
                {
                    case GamePhase.Deploy :
                        InteractionDeploy(hit);
                        break;

                    case GamePhase.Play:
                        InteractionPlay(hit);
                        break;
                }
            }
        }
    }


    // Deploy Phase
    // #1 Select Card > Touch Tile || Select Deployed Piece > Touch Tile (Pass Second UX now)
    // #2 Confirm Button
    // #3 Opposite Turn
    // #4 When both player ready > Enter the Play phase

    private void DeployPiece()
    {
        // Deploy Piece
        // And Delete Card on hand
    }

    public void EndDeploy() // UI Manager 에서 호출
    { 
        _currentPhase = GamePhase.Play;
    }

    private void CheckDelpoymentProgress()
    {
        // Check Progress and if deploy ends, turn next phase
    }


    // Deploy Interaction
    private void InteractionDeploy(RaycastHit hit)
    {
        if (isCardSelected && hit.transform.gameObject.TryGetComponent<BoardTile>(out BoardTile tile))
        {

            isCardSelected = false;

            CheckDelpoymentProgress();
        }
    }



    // Play Phase
    private void ChangeTurn()
    {
        currentTeamTurn = currentTeamTurn == Constants.Team.WHITE ? Constants.Team.BLACK : Constants.Team.WHITE;
        UIManager.uiManager.ChangeTurnImg(currentTeamTurn);
    }


    private ChessPiece selectedPiece;
    private BoardTile selectedTile;

    private bool isPieceSelected = false;

    private void InteractionPlay(RaycastHit hit)
    {
        if (hit.transform.gameObject.GetComponent<ChessPiece>()) // Piece Click
        {
            hit.transform.gameObject.TryGetComponent<ChessPiece>(out ChessPiece piece);
            Debug.Log("Chess Piece Selected - " + piece.gameObject.name);

            if (piece.team == currentTeamTurn) // 현재 팀 순서 체크
            {
                if (isPieceSelected)
                {
                    ClearMoveableArea();
                }

                isPieceSelected = true;

                selectedPiece = piece;
                selectedPiece.CheckPath();

                PrintMoveableArea();
            }
            else if (isPieceSelected && moveableArea.Contains(piece.currentTile)) // 적 말 선택시, 공격 가능한 말인지 체크
            {
                Debug.Log("Piece Moved to Piece " + piece.gameObject.name);

                selectedPiece.Move(piece.currentTile);
                isPieceSelected = false;
                ClearMoveableArea();

                ChangeTurn();
            }

            //Debug.Log("is Piece Same in Array" + selectedPiece.Equals(boardManager.chessPieces[0])); // 값이 다름
        }
        else if (isPieceSelected)
        {
            if (hit.transform.gameObject.TryGetComponent<BoardTile>(out selectedTile)) // Tile Click
            {
                if (moveableArea.Contains(selectedTile))
                {
                    selectedPiece.Move(selectedTile);
                    isPieceSelected = false;
                    ClearMoveableArea();

                    Debug.Log("Piece Moved to Tile " + selectedTile.gameObject.name);

                    ChangeTurn();
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