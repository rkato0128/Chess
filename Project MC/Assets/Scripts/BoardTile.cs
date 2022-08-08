using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public ChessPiece pieceOnTile;

    [Space][Header("Tile Mesh Option")]
    [SerializeField] private MeshRenderer tileMesh;
    [SerializeField] private Color32 tileColBlack;
    [SerializeField] private Color32 tileColWhite;


    // Column : Vertical (A,B,C...) / Row : Horizontal (1,2,3...)
    [SerializeField] private int _column;
    [SerializeField] private int _row;

    public int column{get{return _column;}}
    public int row{get{return _row;}}
    
    public bool isPieceOnTile
    {
        get
        {
            return pieceOnTile ? true : false;
        }
    }


    public void Moveable()
    {
        // For moveable notice test
        tempColor = tileMesh.material.color;
        tileMesh.material.color = Color.red;
    }

    // For moveable notice test
    private Color32 tempColor;

    public void SetTileOriginColor()
    {
        tileMesh.material.color = tempColor;
    }


    // Board Initial Setting
    public void SetTile(int tileColumn, int tileRow, bool isBlack)
    {
        _column = tileColumn;
        _row = tileRow;

        tileMesh.material.color = isBlack ? tileColBlack : tileColWhite;
    }
}