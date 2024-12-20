using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Knight : ChessPiece
{
    public override void CheckPath()
    {
        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x + 1, currentTile.coordinate.y + 2));
        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x + 2, currentTile.coordinate.y + 1));

        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x - 1, currentTile.coordinate.y + 2));
        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x - 2, currentTile.coordinate.y + 1));

        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x + 1, currentTile.coordinate.y - 2));
        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x + 2, currentTile.coordinate.y - 1));

        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x - 1, currentTile.coordinate.y - 2));
        CheckTileMoveable(new Vector2Int(currentTile.coordinate.x - 2, currentTile.coordinate.y - 1));

        PieceSelectedAnim();
    }
}
