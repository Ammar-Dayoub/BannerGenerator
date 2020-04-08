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
        Circle,
        Fill,
    }

    public enum Colour
    {
        White = 35,
        Black = 116,
    }

    public enum BackgroundMesh
    {
        Split = 1,
        Fill = 11,
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
