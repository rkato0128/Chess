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
        PAWN,
        ROOK,
        KNIGHT,
        BISHOP,
        QUEEN,
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
