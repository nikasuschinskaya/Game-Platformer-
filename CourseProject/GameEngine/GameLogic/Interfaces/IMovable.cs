using OpenTK;

namespace GameLogic
{
    public interface IMovable
    {
        Vector2 Speed { get; }
        void Move();
    }
}
