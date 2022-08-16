using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Pawn : ChessPiece
{
    bool isFirstMove = true;

    public override void CheckPath()
    {
        Direction movingDir = (team == Constants.Team.WHITE) ? Direction.POSITIVE : Direction.NEGATIVE;

        // 공격 가능한 경우 처리
        int attackDirection = 1;
        int attackCheckPos;

        for(int i = 0; i < 2; i++)
        {
            attackCheckPos = currentTile.coordinate.x - 1 * attackDirection;

            if(attackCheckPos > -1 && attackCheckPos < BM.boardManager.size.x)
            {
                if(BM.boardManager.board[attackCheckPos, currentTile.coordinate.y + 1 * (int)movingDir].isPieceOnTile)
                {
                    if (BM.boardManager.board[attackCheckPos, currentTile.coordinate.y + 1 * (int)movingDir].pieceOnTile.team != this.team)
                    {
                        BM.boardManager.moveableArea.Add(BM.boardManager.board[attackCheckPos, currentTile.coordinate.y + 1 * (int)movingDir]);
                    }
                }
            }

            attackDirection = -1;
        }

        if(isFirstMove)
        {
            CheckGeneralPath(currentTile.coordinate, Direction.ZERO, movingDir, 2);
            isFirstMove = false;
        }
        else
        {
            CheckGeneralPath(currentTile.coordinate, Direction.ZERO, movingDir);
        }
    }
}
