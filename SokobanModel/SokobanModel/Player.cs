using System.Collections.Generic;

namespace SokobanModel
{
    public class Player
    {
        private int _x;
        private int _y;
        private List<MoveRecord> _moveList = new List<MoveRecord>();

        public Player(int x, int y)
        {
            _x = x;
            _y = y;

        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        internal List<MoveRecord> MoveList { get => _moveList; set => _moveList = value; }
    }
}
