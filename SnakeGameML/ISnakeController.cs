namespace SnakeGameML
{
    public interface ISnakeController
    {
        Steering MakeMove(SteeringInput input);
    }
}