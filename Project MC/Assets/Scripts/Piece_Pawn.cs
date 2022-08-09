using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Pawn : ChessPiece
{
    bool isFirstMove = true;

    public override void CheckPath()
    {
        //BM.boardManager.ClearMoveableArea();

        Direction movingDir = (team == Constants.Team.WHITE) ? Direction.POSITIVE : Direction.NEGATIVE;

        if(isFirstMove)
        {
            CheckGeneralPath(currentTile.coordinate, Direction.ZERO, movingDir, 2);
            isFirstMove = false;
        }
        else
        {
            CheckGeneralPath(currentTile.coordinate, Direction.ZERO, movingDir);
        }

        BM.boardManager.PrintPath();
    }
}
