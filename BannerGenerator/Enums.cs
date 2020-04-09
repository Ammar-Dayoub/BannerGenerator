namespace BannerGenerator
{
    public enum Repeat
    {
        None,
        X,
        Y,
        XY
    }

    public enum AlignX
    {
        Left,
        Centre,
        Right,
    }

    public enum AlignY
    {
        Top,
        Centre,
        Bottom,
    }

    public enum PatternType
    { 
        Line,
        RepeatX,
        RepeatY,
        Cross,
        CrossDiagonal,
        Fill,
    }

    public enum Colour
    {
        White = 35,
        Black = 116,
    }

    public enum BackgroundMesh
    {
        VerticalSplit0 = 1,
        VerticalSplit1,
        CheckeredSquares0,
        CheckeredSquares1,
        CheckeredSquares2,
        CheckeredTriangles0,
        CheckeredTriangles1,
        CheckeredDiamonds0,
        CheckeredDiamonds1,
        Grid,
        Fill,
        DiagonalSplit,
        Triangle0,
        Triangle1,
        Triangle2,
        Triangle3,
        Triangle4,
        Cyclone0,
        Cyclone1,
        Cyclone2,
        Cyclone3,
        Cyclone4,
        DiagonalLine,
        VerticalLine0,
        VerticalLine1,
        EqualsSign,
        Cross,
        X,
        HorizotalStripes,
        DiagonalStripes,
        CentralEmptySquare,
        CentralFullSquare,
        CentralDiamond,
        CentralCircle,
        WaveSplit,
        ZigzagSplit
    }

    public enum Mesh
    {
        Bird0 = 100,
        Bird1,
        Bird2,
        Bird3,
        Bird4,
        Bird5,
        Bird6,
        Bird7,
        Bird8,
        Bird9,
        Bird10,
        Bird11,
        Flora0 = 200,
        Sword0 = 300,
        Pattern0 = 400,
        Circle0 = 500
    }
}
