using OpenTK;

namespace GameLogic
{
    interface IMovable
    {
        Vector2 Speed { get;}
        void Move();
    }
}
