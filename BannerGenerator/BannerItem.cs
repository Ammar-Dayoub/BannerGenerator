using System.Numerics;

namespace BannerGenerator
{
    internal class BannerItem
    {
        public int MeshId;
        public Colour Colour1;
        public Colour Colour2;
        public Vector2 Size;
        public Vector2 Position;
        public bool DrawStroke;
        public bool Mirror;
        public float RotationValue;
    }
}
