using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Knight : ChessPiece
{
    public override void CheckPath()
    {
        // 구현중
        int negative = -1;

        Vector2Int[] position = new Vector2Int[2];

        position[0] = new Vector2Int(1, 2);
        position[0] = new Vector2Int(2, 1);

        // Reverse x y?
    }
}
