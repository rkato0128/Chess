using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_King : ChessPiece
{
    public override void CheckPath()
    {
        // Vertical and horizontal
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.ZERO);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.ZERO);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.POSITIVE);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.NEGATIVE);
        
        // Diagonol
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.POSITIVE);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.POSITIVE);
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.NEGATIVE);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.NEGATIVE);

        PieceSelectedAnim();
    }
}
