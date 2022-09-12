using System.Drawing;

namespace SokobanModel
{
    class MoveRecord
    {
        private Point _currentLocation;
        private Part _currentPart;
        private Point _newLocation;
        private Part _newPart;
        private Point _pushLocation;
        private Part _pushPart;
        
        public MoveRecord(Point point1, Part part1, Point point2, Part part2)
        {
            _currentLocation = point1;
            _currentPart = part1;
            _newLocation = point2;
            _newPart = part2;
        }

        public void SetPushLocationPart(Point point, Part part)
        {
            _pushLocation = point;
            _pushPart = part;
        }

        public Point NewPosition { get => _newLocation; set => _newLocation = value; }
        public Point CurrentPosition { get => _currentLocation; set => _currentLocation = value; }
        public Point PushLocation { get => _pushLocation; set => _pushLocation = value; }
        public Part NewPart { get => _newPart; set => _newPart = value; }
        public Part CurrentPart { get => _currentPart; set => _currentPart = value; }
        public Part PushPart { get => _pushPart; set => _pushPart = value; }
    }
}
