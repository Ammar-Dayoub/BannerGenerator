using System.Numerics;

namespace BannerGenerator
{
    public class BasicProperties {
        public Colour Colour1 { get; set; } // 0-157
        public Colour Colour2 { get; set; } // 0-157
        public float Rotation { get; set; }
    }

    public class BackgroundGeneratorParams : BasicProperties
    {
        public BackgroundMesh MeshId { get; set; } // 1-36
    }

    public class ItemGeneratorParams : BasicProperties
    {
        public Mesh MeshId { get; set; }
        public Vector2 Size { get; set; }
        public Vector2? Position { get; set; }
        public bool DrawStroke { get; set; }
        public bool Mirror { get; set; }
        public AlignX AlignX { get; set; }
        public AlignY AlignY { get; set; }
    }

    public class Pattern : BasicProperties
    {
        public Mesh MeshId { get; set; }
        public Vector2 Size { get; set; }
    }

    public class PatternGeneratorParams : Pattern
    {
        public PatternType Type { get; set; }
        public int Margin { get; set; }
    }

    public class CircleGeneratorParams : Pattern
    {
        public int Amount { get; set; }
        public float Radius { get; set; }
        public bool AutomaticRotation { get; set; }
        public Vector2? Centre { get; set; }
    }
}
