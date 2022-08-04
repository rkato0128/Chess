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

    [SerializeField] private BoardManager boardManager;

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
                if(hit.transform.gameObject.TryGetComponent<ChessPiece>(out ChessPiece chess)) // Chess Piece Click - GetComponent<>() bool 타입 반환?
                {
                    selectedPiece = chess;
                    currentTurnState = TurnState.PATHSELECT;
                    
                    Debug.Log("Chess Piece Selected");
                }
                break;

            case(TurnState.PATHSELECT):
                if(hit.transform.gameObject.GetComponent<BoardTile>()) // Tile Click
                {
                    selectedTile = hit.transform.gameObject.GetComponent<BoardTile>();
                    selectedPiece.Move(selectedTile);
                    currentTurnState = TurnState.PIECESELECT;
                    
                    Debug.Log("Piece Moved to Tile " + selectedTile.gameObject.name);
                }
                break;
        }
    }
}
