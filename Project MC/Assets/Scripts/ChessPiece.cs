using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    // prefab 단에서 설정
    [Header("Piece Initial Option")]
    public Constants.UnitType type;

    [Space]
    public Constants.Team team;
    public BoardTile currentTile;
    
    
    public void Move(BoardTile targetTile)
    {
        currentTile.pieceOnTile = null;

        targetTile.pieceOnTile = this;
        this.gameObject.transform.localPosition = new Vector3(targetTile.transform.localPosition.x, 2, targetTile.transform.localPosition.z);

        currentTile = targetTile;
    }

    public void Set(Constants.Team setTeam, BoardTile setTile)
    {
        team = setTeam;

        currentTile = setTile;
        currentTile.pieceOnTile = this;
    }
}
