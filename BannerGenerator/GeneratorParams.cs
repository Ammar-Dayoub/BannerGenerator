using System.Numerics;

namespace BannerGenerator
{
    public class Coloured {
        public Colour Colour1 { get; set; } // 0-157
        public Colour Colour2 { get; set; } // 0-157
    }

    public class BackgroundGeneratorParams : Coloured
    {
        public BackgroundMesh MeshId { get; set; } // 1-36
    }

    public class ItemGeneratorParams : Coloured
    {
        public Mesh MeshId { get; set; }
        public Vector2 Size { get; set; }
        public Vector2? Position { get; set; }
        public bool DrawStroke { get; set; }
        public bool Mirror { get; set; }
        public AlignX AlignX { get; set; }
        public AlignY AlignY { get; set; }
        public float Rotation { get; set; }
    }

    public class PatternGeneratorParams : Coloured
    {
        public Mesh MeshId { get; set; }
        public Vector2 Size { get; set; }
        public PatternType Type { get; set; }
        public int Margin { get; set; }
    }
}
