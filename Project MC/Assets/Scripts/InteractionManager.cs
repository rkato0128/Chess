using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public enum TurnState
    {
        PIECESELECT,
        PATHSELECT
    }

    public TurnState currentTurnState;

    //[SerializeField] private BM boardManager;

    private void Start()
    {
        currentTurnState = TurnState.PIECESELECT;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast Hit : " + hit.transform.gameObject.name);
                Interaction(hit);
            }
        }
    }

    
    private ChessPiece selectedPiece;
    private BoardTile selectedTile;

    void Interaction(RaycastHit hit)
    {
        switch(currentTurnState)
        {
            case(TurnState.PIECESELECT):
                if(hit.transform.gameObject.TryGetComponent<ChessPiece>(out ChessPiece piece))
                {
                    selectedPiece = piece;
                    currentTurnState = TurnState.PATHSELECT;
                    //boardManager.CheckPiecePath(selectedPiece);
                    piece.CheckPath();
                    
                    Debug.Log("Chess Piece Selected");

                    //Debug.Log("is Piece Same in Array" + selectedPiece.Equals(boardManager.chessPieces[0])); // 값이 다름? - 식별 인덱스 추가
                }
                break;

            case(TurnState.PATHSELECT):
                if(hit.transform.gameObject.GetComponent<BoardTile>()) // Tile Click
                {
                    selectedTile = hit.transform.gameObject.GetComponent<BoardTile>();
                    selectedPiece.Move(selectedTile);
                    currentTurnState = TurnState.PIECESELECT;

                    // For test
                    // foreach(BoardTile temp in boardManager.moveableArea)
                    // {
                    //     temp.SetTileOriginColor(); 
                    // }

                    Debug.Log("Piece Moved to Tile " + selectedTile.gameObject.name);
                }
                break;
        }
    }
}
