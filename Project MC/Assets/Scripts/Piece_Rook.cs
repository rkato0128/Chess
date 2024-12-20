using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Rook : ChessPiece
{
    public override void CheckPath()
    {
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.ZERO, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.ZERO, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.POSITIVE, BM.boardManager.size.y);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.NEGATIVE, BM.boardManager.size.y);

        PieceSelectedAnim();
    }
}
