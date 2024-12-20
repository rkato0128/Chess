using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Queen : ChessPiece
{
    public override void CheckPath()
    {
        // Vertical and horizontal
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.ZERO, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.ZERO, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.POSITIVE, BM.boardManager.size.y);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.NEGATIVE, BM.boardManager.size.y);
        
        // Diagonol
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.POSITIVE, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.POSITIVE, BM.boardManager.size.x);
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.NEGATIVE, BM.boardManager.size.y);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.NEGATIVE, BM.boardManager.size.y);

        PieceSelectedAnim();
    }
}
