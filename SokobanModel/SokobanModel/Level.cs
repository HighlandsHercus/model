using System;
using System.Collections.Generic;
using System.Drawing;


namespace SokobanModel
{
    public class Level: ILevel
    {
        private Player _player = null;
        private string _levelName;
        private int _levelHeight;
        private int _levelWidth;
        private List<Point> _goalList = new List<Point>();
        private List<List<Part>> _gridList = new List<List<Part>>();

        public Level(string name="Untitled")
        {
            LevelName = name;
        }

        public void CreateLevel(int width, int height)
        {
            // Creates the Square/Rectangular grid for the level
            _levelHeight = height;
            _levelWidth = width;
            for (int i = 0; i < height; i++)
            {
                List<Part> blank = new List<Part>();
                for (int j = 0; j < width; j++)
                {
                    blank.Add(Part.Empty);
                }
                GridList.Add(blank);
            }
        }

        public int GetLevelHeight()
        {
            return _levelHeight;
        }

        public int GetLevelWidth()
        {
            return _levelWidth;
        }

        public void AddBlock(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {
                GridList[gridY][gridX] = Part.Block;
            }
        }

        public void AddBlockOnGoal(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {
                GridList[gridY][gridX] = Part.BlockOnGoal;
            }
        }

        public void AddEmpty(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {
                GridList[gridY][gridX] = Part.Empty;
            }
        }

        public void AddGoal(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {
                GridList[gridY][gridX] = Part.Goal;
            }
        }

        public void AddPlayer(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {   // If Player already exists, set old player to Empty, Create player at new Point
                if (_player == null)
                {
                    _player = new Player(gridY, gridX);
                }
                else
                {
                    GridList[Player.Y][Player.X] = Part.Empty;
                }
                GridList[gridY][gridX] = Part.Player;
                Player.X = gridX;
                Player.Y = gridY;
            }
        }

        public void AddPlayerOnGoal(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {   // If Player already exists, set old player to Empty, Create player on goal at new Point
                if (_player == null)
                {
                    _player = new Player(gridY, gridX);
                }
                else
                {
                    GridList[Player.X][Player.Y] = Part.Empty;
                }
                GridList[gridY][gridX] = Part.PlayerOnGoal;
                Player.X = gridX;
                Player.Y = gridY;
            }
        }

        public void AddWall(int gridX, int gridY)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {
                GridList[gridY][gridX] = Part.Wall;
            }
        }

        public Part GetPartAtIndex(int gridX, int gridY)
        {
            return GridList[gridY][gridX];
        }
  
        public void SaveMe()
        {
            // Go through grid list, any goals need to be added when saved_goalList.Add(new Point(gridX, gridY));
        }

        public bool CheckValid()
        {
            if (LevelName.Length >= 1 || LevelName != "Untitled")
            {
                if (_levelWidth < 1 || _levelHeight < 1)
                {
                    if (_player == null)
                    {
                        foreach (List<Part> i in GridList)
                        {
                            foreach (Part j in i)
                            {
                                if (j == Part.Goal)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void addPart(int gridX, int gridY, Part part)
        {
            if (gridX > GetLevelWidth() - 1 || gridY > GetLevelHeight() - 1)
            {
                throw new IndexOutOfRangeException("Unexpected");
            }
            else
            {
                GridList[gridY][gridX] = part;
            }
        }

        public void RemovePart(int gridX, int gridY)
        {
            AddEmpty(gridX, gridY);
        }

        public string LevelName { get => _levelName; set => _levelName = value; }
        public Player Player { get => _player; set => _player = value; }
        public List<Point> GoalList { get => _goalList; set => _goalList = value; }
        internal List<List<Part>> GridList { get => _gridList; set => _gridList = value; }
    }
}
