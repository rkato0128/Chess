using System.Collections;
using System.Collections.Generic;

public static class Constants
{
    public enum Team
    {
        WHITE,
        BLACK
    }

    public enum PieceType
    {
        PAWN = 1,
        ROOK = 2,
        KNIGHT = 3,
        BISHOP = 4,
        QUEEN = 5,
        KING
    }

    public static Dictionary<PieceType, int> PieceCost = new Dictionary<PieceType, int>()
    {
        {PieceType.PAWN, 1},
        {PieceType.ROOK, 5},
        {PieceType.KNIGHT, 3},
        {PieceType.BISHOP, 3},
        {PieceType.QUEEN, 9}
    };
}
