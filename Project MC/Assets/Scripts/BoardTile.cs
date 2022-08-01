using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public Vector3 tilePostion;
    public ChessUnit chessUnit;

    public bool isUnitOnTile()
    {
        return !chessUnit?false:true;
    }

    public BoardTile()
    {

    }
}