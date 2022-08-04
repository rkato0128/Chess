using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public Constants.UnitType pieceType;

    // public ChessPiece(Constants.UnitType pieceType)
    // {

    // }
    
    public BoardTile currentTile;
    
    public void Move(BoardTile targetTile)
    {
        currentTile.pieceOnTile = null;

        targetTile.pieceOnTile = this;
        this.gameObject.transform.localPosition = new Vector3(targetTile.transform.localPosition.x, 2, targetTile.transform.localPosition.z);

        currentTile = targetTile;
    }
}
