using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public ChessPiece chessUnit;

    [Space]

    [SerializeField] private MeshRenderer tileMesh;
    [SerializeField] private Color32 tileColBlack;
    [SerializeField] private Color32 tileColWhite;

    public void SetTileColor(bool isBlack)
    {
        tileMesh.material.color = isBlack ? tileColBlack : tileColWhite;
    }
    
    public bool isUnitOnTile()
    {
        return chessUnit ? true : false;
    }
}