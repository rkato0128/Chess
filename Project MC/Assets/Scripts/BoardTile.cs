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


    public bool isUnitOnTile
    {
        get
        {
            return pieceOnTile ? true : false;
        }
    }

    public void Moveable()
    {
        // 이동 가능 타일 연출 출력
    }

    // Board Initial Setting
    public void SetTileColor(bool isBlack)
    {
        tileMesh.material.color = isBlack ? tileColBlack : tileColWhite;
    }
}