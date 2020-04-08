using System.Text;
using System.Collections.Generic;
using System.Numerics;

namespace BannerGenerator
{
    public static class Utilities
    {
        #region Constants
        // TOP LEFT is 0,0
        // Never Change
        private const int DIMENSION = 1540; // TODO Make these public to help with line pattern
        private const int BANNER_DIMENSION_Y = 760;
        private const float ROTATION_PRECISION = 0.00278f;
        private const float OFFSET_Y = 25; // THe flag does not render show the exact centre

        // Calculated
        private static readonly Vector2 CENTRE = new Vector2 { X = DIMENSION / 2, Y = (DIMENSION / 2) - OFFSET_Y };
        private static readonly int INNER_TOP_Y = (int)CENTRE.Y - (BANNER_DIMENSION_Y / 2);
        private static readonly int INNER_BOTTOM_Y = (int)CENTRE.Y + (BANNER_DIMENSION_Y / 2);

        // Suggested item size for shields and such
        public static Vector2 SUGGESTED_ITEM_DIMENSIONS = new Vector2 { X = 300, Y = 300 };
        #endregion

        public static string Generate(BackgroundGeneratorParams background, List<ItemGeneratorParams> items)
        {
            // Add background
            var bannerItems = new List<BannerItem> {
                GenerateBackground(background),
            };

            // Add items
            foreach (var item in items)
            {
                bannerItems.Add(GenerateItem(item));
            };

            return Serialise(bannerItems);
        }

        public static string Generate(BackgroundGeneratorParams background, PatternGeneratorParams pattern)
        {
            // Add background
            var items = new List<BannerItem> {
                GenerateBackground(background),
            };

            // Add items
            switch (pattern.Type)
            {
                case PatternType.Line:
                    // TODO expose custom line pattern
                    // items.AddRange(PatternForRepeatCustom(pattern, startPoint, endPoint));
                    break;
                case PatternType.RepeatX:
                    items.AddRange(PatternForRepeatX(pattern));
                    break;
                case PatternType.RepeatY:
                    items.AddRange(PatternForRepeatY(pattern));
                    break;
                case PatternType.Cross:
                    items.AddRange(PatternForCross(pattern));
                    break;
                case PatternType.CrossDiagonal:
                    items.AddRange(PatternForCrossDiagonal(pattern));
                    break;
                case PatternType.Fill:
                    // TODO
                    // items.AddRange(PatternForFill(pattern));
                    break;
                case PatternType.Circle:
                    // TODO circle... yeah...
                    // items.AddRange(PatternForCircle(pattern));
                    break;
                default:
                    break;
            };

            return Serialise(items);
        }

        #region Patterns
        private static List<BannerItem> PatternForLine(PatternGeneratorParams pattern, Vector2 startPoint, Vector2 endPoint)
        {
            var distance = Vector2.Distance(startPoint, endPoint);
            float canFit = distance / pattern.Margin;
            var diff = Vector2.Subtract(endPoint, startPoint);

            int stepX = (int)(diff.X / canFit), stepY = (int)(diff.Y / canFit);

            var items = new List<BannerItem>();
            for (int i = 0; i <= canFit; i++)
            {
                items.Add(GenerateItem(new ItemGeneratorParams
                {
                    MeshId = pattern.MeshId,
                    Colour1 = pattern.Colour1,
                    Colour2 = pattern.Colour2,
                    Size = pattern.Size,
                    Position = new Vector2(startPoint.X + (i * stepX), startPoint.Y + (i * stepY)),
                    Rotation = 0,
                }));
            }
            return items;
        }

        private static List<BannerItem> PatternForRepeatX(PatternGeneratorParams pattern)
        {
            return PatternForLine(pattern, new Vector2(0, CENTRE.Y), new Vector2(DIMENSION, CENTRE.Y));
        }

        private static List<BannerItem> PatternForRepeatY(PatternGeneratorParams pattern)
        {
            return PatternForLine(pattern, new Vector2(CENTRE.X, INNER_TOP_Y), new Vector2(CENTRE.X, INNER_BOTTOM_Y));
        }

        private static List<BannerItem> PatternForCross(PatternGeneratorParams pattern)
        {
            var items = new List<BannerItem>();
            items.AddRange(PatternForRepeatX(pattern));
            items.AddRange(PatternForRepeatY(pattern));
            return items;
        }

        private static List<BannerItem> PatternForCrossDiagonal(PatternGeneratorParams pattern)
        {
            var items = new List<BannerItem>();
            items.AddRange(PatternForLine(pattern, new Vector2(0, INNER_TOP_Y), new Vector2(DIMENSION, INNER_BOTTOM_Y)));
            items.AddRange(PatternForLine(pattern, new Vector2(0, INNER_BOTTOM_Y), new Vector2(DIMENSION, INNER_TOP_Y)));
            return items;
        }

        //private static List<BannerItem> PatternForFill(PatternGeneratorParams pattern)
        //{
        //    var items = new List<BannerItem>();
        //    // DO STUFF
        //    return items;
        //}

        //private static List<BannerItem> PatternForCircle(PatternGeneratorParams pattern)
        //{
        //    var items = new List<BannerItem>();
        //    // DO STUFF
        //    return items;
        //}
        #endregion

        #region Helpers
        private static BannerItem GenerateBackground(BackgroundGeneratorParams background)
        {
            var size = new Vector2(DIMENSION, BANNER_DIMENSION_Y);
            return new BannerItem
            {
                MeshId = (int)background.MeshId,
                ColorId = (int)background.Colour1,
                ColorId2 = (int)background.Colour2,
                Size = size,
                Position = GetPositionByAlignment(size, AlignX.Centre, AlignY.Centre),
                DrawStroke = false,
                Mirror = false,
                RotationValue = 0
            };
        }

        private static BannerItem GenerateItem(ItemGeneratorParams item)
        {
            Vector2? position;
            if (item.Position != null)
                position = item.Position;
            else
            {
                position = GetPositionByAlignment(item.Size, item.AlignX, item.AlignY);
            }
            return new BannerItem
            {
                MeshId = (int)item.MeshId,
                ColorId = (int)item.Colour1,
                ColorId2 = (int)item.Colour2,
                Size = item.Size,
                Position = (Vector2)position,
                DrawStroke = item.DrawStroke,
                Mirror = item.Mirror,
                RotationValue = item.Rotation
            };
        }

        private static string Serialise(List<BannerItem> BannerItems)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool first = true;
            foreach (BannerItem bannerItem in BannerItems)
            {
                if (!first)
                {
                    stringBuilder.Append('.');
                }
                first = false;
                stringBuilder.Append(bannerItem.MeshId);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.ColorId);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.ColorId2);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.Size.X);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.Size.Y);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.Position.X);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.Position.Y);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.DrawStroke ? 1 : 0);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.Mirror ? 1 : 0);
                stringBuilder.Append('.');
                stringBuilder.Append(bannerItem.RotationValue / ROTATION_PRECISION);
            }
            return stringBuilder.ToString();
        }

        private static Vector2 GetPositionByAlignment(Vector2 size, AlignX alignX, AlignY alignY)
        {
            float x = CENTRE.X;
            float y = CENTRE.Y;
            switch (alignX)
            {
                case AlignX.Left:
                    {
                        x = size.X / 2;
                        break;
                    }
                case AlignX.Right:
                    {
                        x = DIMENSION - size.X / 2;
                        break;
                    }
            }
            switch (alignY)
            {
                case AlignY.Top:
                    {
                        y = INNER_TOP_Y + (size.Y / 2);
                        break;
                    }
                case AlignY.Bottom:
                    {
                        y = INNER_BOTTOM_Y - (size.Y / 2);
                        break;
                    }
            }
            return new Vector2 { X = x, Y = y };
        }
        #endregion
    }
}
