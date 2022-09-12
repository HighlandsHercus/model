namespace SokobanModel
{
    public interface IGame
    {
        void Move(Direction moveDirection);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Load(string newLevel);

        // Methods I've Implemented myself
        void AddLevel(Level level);
        void RemoveLevel(Level level);
    }
}
