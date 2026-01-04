namespace Blockade
{
    internal class DrawerShape
    {
        private readonly Shape _shape;
        public List<Rectangle> Blocks { get; }

        public DrawerShape(Shape shape, List<Rectangle> blocks)
        {
            _shape = shape;
            Blocks = blocks;
        }
    }
}