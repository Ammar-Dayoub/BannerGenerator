using System.Numerics;

namespace BannerGenerator
{
    internal class BannerItem
    {
        public const float RotationPrecision = 0.00278f;

        public int MeshId;
        public int ColorId;
        public int ColorId2;
        public Vector2 Size;
        public Vector2 Position;
        public bool DrawStroke;
        public bool Mirror;
        public float RotationValue;
    }
}
