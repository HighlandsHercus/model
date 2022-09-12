using System.Drawing;


namespace SokobanModel
{
    interface IMoving
    {
        public bool CheckMoveInvolvingNoPush(int gridX, int gridY);
        public bool CheckMoveInvolvingPush(int gridX1, int gridY1, int gridX2, int gridY2);
        public bool CheckPointInBoundsOfLevel(int gridX, int gridY);
        public Point GetPointForMove(Direction moveDirection, int gridX, int gridY);
        public Point GetPointForBlockPush(Direction moveDirection, int gridX, int gridY);
        public void UpdateOldLocation(int gridX, int gridY);
        public void UpdateNewLocation(int gridX, int gridY);
        public void UpdateBlockPushLocation(int gridX, int gridY);
    }
}
