using Blockade.Math;
using Raylib_cs;

namespace Blockade
{
    internal class Drawer
    {
        private static readonly int BORDER_WIDTH = 20;
        private static readonly int BORDER_HEIGHT = 20;
        private static readonly int DRAWER_WIDTH = 500;
        private static readonly double PARTITION_RATIO = 0.10;
        private static readonly Color DRAWER_COLOR = Color.White;
        private static readonly int CONTAINER_PADDING = 10;
        private static readonly int TEXT_FONT_SIZE = 20;
        private static readonly Color TEXT_COLOR = Color.Black;
        private static readonly int BLOCK_SIZE = 40;

        private readonly Player _player;
        private readonly List<Shape> _shapes;
        private int _screenWidth;
        private int _screenHeight;
        private int DrawerX => _screenWidth - DRAWER_WIDTH;
        private int DrawerY => 0;

        public int MainPadding => CONTAINER_PADDING;
        public int InteriorPadding => 10;
        public int FontSize => TEXT_FONT_SIZE;
        public int TileSize => 40;
        public int TileGap => 2;

        private readonly List<DrawerShape> _drawerShapes;

        int ScoreAreaHeight => FontSize + 2 * InteriorPadding;

        public (Vec2i gridSize, Rec2i gridArea) GetGridArea(ref Rec2i area)
        {
            var tilesWide = 3;

            while (((tilesWide + 1) * TileSize) + tilesWide * TileGap <= area.W)
            {
                tilesWide++;
            }

            var tilesHigh = 3;
            while (((tilesHigh + 1) * TileSize) + tilesHigh * TileGap <= area.H)
            {
                tilesHigh++;
            }

            var width = tilesWide * TileSize + (tilesWide - 1) * TileGap;
            var height = tilesHigh * TileSize + (tilesHigh - 1) * TileGap;

            return (new(tilesWide, tilesHigh), new()
            {
                X = area.X + (area.W - width) / 2,
                Y = area.Y + (area.H - height) / 2,
                W = width,
                H = height,
            });
        }

        public Rec2i GetContentArea(ref Rec2i area)
            => area.Shrink(MainPadding, MainPadding);

        public Rec2i GetScoreArea(ref Rec2i area) => new()
        {
            X = area.X,
            Y = area.Y,
            W = area.W,
            H = ScoreAreaHeight,
        };

        public Rec2i GetShapeArea(ref Rec2i area) => new()
        {
            X = area.X,
            Y = area.Y + ScoreAreaHeight + MainPadding,
            W = area.W,
            H = area.H - ScoreAreaHeight - MainPadding,
        };

        // private List<DrawerShape> DetermineBlockPositions()
        // {
        //     List<DrawerShape> drawerShapes = [];
        //     Rectangle blockArea = GetBlocksAreaDimensions();
        //     var position = new Vec2i(0, 0);
        //     int yOffset = 0;
        //     int xOffset = 0;
        //     int maxHeightInRow = 0;
        //
        //     for (int i = 0; i < _shapes.Count; i++)
        //     {
        //         Shape shape = _shapes[i];
        //         List<Rectangle> blockRectangles = [];
        //         var positions = shape.MapPlacementAt(position);
        //
        //         int remainingWidth = blockArea.Width - 2 * CONTAINER_PADDING - xOffset;
        //         if (remainingWidth < BLOCK_SIZE * shape.Dimensions.Width)
        //         {
        //             xOffset = 0;
        //             yOffset += maxHeightInRow + CONTAINER_PADDING;
        //         }
        //
        //         var height = shape.Dimensions.Height * BLOCK_SIZE;
        //         if (maxHeightInRow < height)
        //             maxHeightInRow = height;
        //
        //         foreach (Vec2i pos in positions)
        //         {
        //             Rectangle blockRect = new Rectangle(
        //                 blockArea.X + CONTAINER_PADDING + pos.X * BLOCK_SIZE + xOffset,
        //                 blockArea.Y + CONTAINER_PADDING + pos.Y * BLOCK_SIZE + yOffset,
        //                 BLOCK_SIZE,
        //                 BLOCK_SIZE,
        //                 Color.Gray
        //             );
        //
        //             blockRectangles.Add(blockRect);
        //         }
        //
        //         xOffset += BLOCK_SIZE * shape.Dimensions.Width + CONTAINER_PADDING;
        //         drawerShapes.Add(new DrawerShape(shape, blockRectangles));
        //     }
        //
        //     return drawerShapes;
        // }

        public Drawer(Player player, List<Shape> shapes, int screenWidth, int screenHeight)
        {
            _player = player;
            _shapes = shapes;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            // _drawerShapes = DetermineBlockPositions();
        }

        public Rectangle GetDrawerDimensions()
        {
            return new Rectangle(
                DrawerX, 
                DrawerY, 
                DRAWER_WIDTH, 
                _screenHeight, 
                DRAWER_COLOR
            );
        }

        public Rectangle GetScoreAreaDimensions()
        {
            return new Rectangle(
                DrawerX + BORDER_WIDTH,
                DrawerY + BORDER_HEIGHT,
                DRAWER_WIDTH - 2 * BORDER_WIDTH,
                (int)((_screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO),
                Color.White
            );
        }

        public Rectangle GetBlocksAreaDimensions()
        {
            return new Rectangle(
                DrawerX + BORDER_WIDTH,
                DrawerY + BORDER_HEIGHT + (int)((_screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO),
                DRAWER_WIDTH - 2 * BORDER_WIDTH,
                _screenHeight - 2 * BORDER_HEIGHT - (int)((_screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO),
                Color.LightGray
            );
        }

        public string GetScoreString()
        {
            return $"{84}/{84} blocks placed | Score: {0} points";
        }

        public Text GetScoreText()
        {
            string scoreContent = $"{84}/{84} blocks placed | Score: {0} points";
            int boxYEnd = (int)((_screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO);

            return new Text(
                scoreContent,
                TEXT_FONT_SIZE,
                DrawerX + BORDER_WIDTH + CONTAINER_PADDING,
                boxYEnd - CONTAINER_PADDING,
                TEXT_COLOR
            );
        }

        public List<DrawerShape> GetDrawerShapes()
        {
            return _drawerShapes;
        }

        private Rec2i MapTileToRect(ref Rec2i gridArea, int tx, int ty) => new()
        {
            X = gridArea.X + tx * (TileSize + TileGap),
            Y = gridArea.Y + ty * (TileSize + TileGap),
            W = TileSize,
            H = TileSize,
        };

        public IEnumerable<Rec2i> GetTileAreas(Vec2i gridSize, Rec2i gridArea)
        {
            for (var x = 0; x < gridSize.X; x++)
            {
                for (var y = 0; y < gridSize.Y; y++)
                {
                    yield return MapTileToRect(ref gridArea, x, y);
                }
            }
        }

        public IEnumerable<Rec2i> GetFilledTileAreas(Vec2i gridSize, Rec2i gridArea)
        {
            // Grid coords
            int tx = 0, ty = 0;

            int rowHeight = 0;

            // TODO: mutable shapes list
            foreach (var shape in _shapes)
            {
                if (gridSize.X < tx + shape.Width)
                {
                    tx = 0;
                    ty += rowHeight + 1;
                    rowHeight = 0;
                }

                foreach (var pos in shape.MapPlacementAt(new(tx, ty)))
                {
                    yield return MapTileToRect(ref gridArea, pos.X, pos.Y);
                }

                tx += shape.Width + 1;
                rowHeight = System.Math.Max(rowHeight, shape.Height);
            }
        }


        // public IEnumerable<(List<List<Rec2i>> shapes, int height)> GetShapeRows(int tilesWide, int tilesHigh)
        // {
        //     List<List<Rec2i>> row = [];
        //     var width = 0;
        //     var height = 0;
        //
        //     foreach (var shape in _shapes)
        //     {
        //         if (width == 0)
        //         {
        //             row.Add(new(shape));
        //             height = System.Math.Max(shape.Height, height);
        //             width += shape.Width;
        //         }
        //
        //         else if (tilesWide < width + 1 + shape.Width)
        //         {
        //             yield return (row, height);
        //             row = [new(shape)];
        //             height = shape.Height;
        //             width = shape.Width;
        //         }
        //
        //         else
        //         {
        //             row.Add(new(shape));
        //             height = System.Math.Max(shape.Height, height);
        //             width += shape.Width + 1;
        //         }
        //     }
        // }
    }
}