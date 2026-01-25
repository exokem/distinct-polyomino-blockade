using Blockade.Math;

namespace Blockade;

public interface ITransform
{
    Vec2i Apply(ref Vec2i pos, ref Vec2i center);
}

// public class RotationTransform : ITransform
// {
//     public Vec2i Apply(ref Vec2i pos, ref Vec2i center)
//     {
//
//         throw new NotImplementedException();
//     }
// }