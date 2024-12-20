using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Bishop : ChessPiece
{
    public override void CheckPath()
    {
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.POSITIVE, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.POSITIVE, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.NEGATIVE, BM.boardManager.size.y);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.NEGATIVE, BM.boardManager.size.y);

        PieceSelectedAnim();
    }
}
