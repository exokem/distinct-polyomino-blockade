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

        private readonly List<DrawerShape> _drawerShapes;

        private List<DrawerShape> DetermineBlockPositions()
        {
            List<DrawerShape> drawerShapes = [];
            Rectangle blockArea = GetBlocksAreaDimensions();
            Vector2Int position = new Vector2Int(0, 0);

            for (int i = 0; i < _shapes.Count; i++)
            {
                Shape shape = _shapes[i];
                List<Rectangle> blockRectangles = [];
                List<Vector2Int> positions = shape.MapPlacementAt(position);

                foreach (Vector2Int pos in positions)
                {
                    Rectangle blockRect = new Rectangle(
                        blockArea.X + CONTAINER_PADDING + pos.X * BLOCK_SIZE,
                        blockArea.Y + CONTAINER_PADDING + pos.Y * BLOCK_SIZE + (i * (CONTAINER_PADDING + BLOCK_SIZE)),
                        BLOCK_SIZE,
                        BLOCK_SIZE,
                        Color.Gray
                    );
                    blockRectangles.Add(blockRect);
                }

                drawerShapes.Add(new DrawerShape(shape, blockRectangles));
            }

            return drawerShapes;
        }

        public Drawer(Player player, List<Shape> shapes, int screenWidth, int screenHeight)
        {
            _player = player;
            _shapes = shapes;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            _drawerShapes = DetermineBlockPositions();
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
    }
}