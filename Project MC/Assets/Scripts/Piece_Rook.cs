using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Rook : ChessPiece
{
    public override void CheckPath()
    {
        CheckGeneralPath(currentTile.coordinate, Direction.NEGATIVE, Direction.ZERO, 6);
        CheckGeneralPath(currentTile.coordinate, Direction.POSITIVE, Direction.ZERO, 6);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.POSITIVE, 6);
        CheckGeneralPath(currentTile.coordinate, Direction.ZERO, Direction.NEGATIVE, 6);

        //BM.boardManager.PrintPath();
    }
}
