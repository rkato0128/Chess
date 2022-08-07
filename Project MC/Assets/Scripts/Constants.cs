using System.Collections;
using System.Collections.Generic;

public static class Constants
{
    public enum Team
    {
        WHITE,
        BLACK
    }

    public enum UnitType
    {
        PAWN,
        ROOK,
        KNIGHT,
        BISHOP,
        QUEEN,
        KING
    }

    public enum UnitMovingType
    {
        VERTICAL,
        HORIZONTAL,
        DIAGONAL,
        KNIGHT
    }
}
