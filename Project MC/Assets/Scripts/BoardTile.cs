using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public ChessPiece pieceOnTile;

    // coordinate.x = Column = Vertical (A,B,C...) / coordinate.y = Row = Horizontal (1,2,3...)
    private Vector2Int _coordinate = new Vector2Int();
    public Vector2Int coordinate{get{return _coordinate;}}

    [Space][Header("Tile Mesh Option")]
    [SerializeField] private MeshRenderer tileMesh;
    [SerializeField] private Color32 tileColBlack;
    [SerializeField] private Color32 tileColWhite;
    

    // For moveable notice test
    private Color32 originColor;
    

    public bool isPieceOnTile
    {
        get
        {
            return pieceOnTile ? true : false;
        }
    }

    public void Moveable()
    {
        tileMesh.material.color = (originColor * Color.red) * 0.3f + (originColor + Color.red) * 0.7f;
    }

    public void SetTileOriginColor()
    {
        tileMesh.material.color = originColor;
    }


    // Board Initial Setting
    public void SetTile(int x, int y, bool isBlack)
    {
        _coordinate.x = x;
        _coordinate.y = y;

        originColor = isBlack ? tileColBlack : tileColWhite;
        tileMesh.material.color = originColor;
    }
}