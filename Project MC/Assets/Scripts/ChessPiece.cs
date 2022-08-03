using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public ChessPiece(Constants.UnitType unitType)
    {

    }
    
    public BoardTile currentTile;
    
    public void Move(BoardTile targetTile)
    {
        currentTile.chessPiece = null; // 멤버 변수 초기화 어떻게?
        System.GC.Collect();

        targetTile.chessPiece = this;
        this.gameObject.transform.localPosition = new Vector3(targetTile.transform.localPosition.x, 2, targetTile.transform.localPosition.z);
    }
}
