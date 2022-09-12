using System;
using System.Collections.Generic;
using System.Drawing;

namespace SokobanModel
{
    public class Game : IGame, IMoving
    {
        private List<Level> _levelList = new List<Level>();
        private Level _currentLevel;

        public void Load(string newLevel)
        {
            foreach (Level i in LevelList)
            {
                if (i.LevelName == newLevel)
                {
                    CurrentLevel = i;
                    // This is not a clone, it is a pointer to the Level in the list 
                }
            }
        }

        public void AddLevel(Level level)
        {
            /*            if (level.CheckValid() == true)
                        {
                            level.SaveMe();
                            LevelList.Add(level);
                        }*/
            level.SaveMe();
            LevelList.Add(level);
        }

        public void RemoveLevel(Level level)
        {
        }

        public void Move(Direction moveDirection)
        {
            Point point0 = new Point(CurrentLevel.Player.X, CurrentLevel.Player.Y);
            Point point1 = GetPointForMove(moveDirection, CurrentLevel.Player.X, CurrentLevel.Player.Y);
            Point point2 = GetPointForBlockPush(moveDirection, CurrentLevel.Player.X, CurrentLevel.Player.Y);

            if (CheckMoveInvolvingNoPush(point1.X, point1.Y))
            {
                CurrentLevel.Player.MoveList.Add(new MoveRecord(point0, CurrentLevel.GetPartAtIndex(point0.X, point0.Y), point1, CurrentLevel.GetPartAtIndex(point1.X, point1.Y)));
                UpdateOldLocation(CurrentLevel.Player.X, CurrentLevel.Player.Y);
                UpdateNewLocation(point1.X, point1.Y);
            }
            else if (CheckMoveInvolvingPush(point1.X, point1.Y, point2.X, point2.Y))
            {
                MoveRecord moveRecord = new MoveRecord(point0, CurrentLevel.GetPartAtIndex(point0.X, point0.Y), point1, CurrentLevel.GetPartAtIndex(point1.X, point1.Y));
                moveRecord.SetPushLocationPart(point2, CurrentLevel.GetPartAtIndex(point2.X, point2.Y));
                CurrentLevel.Player.MoveList.Add(moveRecord);
                UpdateOldLocation(CurrentLevel.Player.X, CurrentLevel.Player.Y);
                UpdateNewLocation(point1.X, point1.Y);
                UpdateBlockPushLocation(point2.X, point2.Y);
            }
        }

        public void UpdateOldLocation(int gridX, int gridY)
        {
            if (CurrentLevel.GridList[gridY][gridX] == Part.PlayerOnGoal)
            {
                CurrentLevel.GridList[gridY][gridX] = Part.Goal;
            }
            else
            {
                CurrentLevel.GridList[gridY][gridX] = Part.Empty;
            }

        }

        public void UpdateNewLocation(int gridX, int gridY)
        {
            if (CurrentLevel.GridList[gridY][gridX] == Part.Goal || CurrentLevel.GridList[gridY][gridX] == Part.BlockOnGoal)
            {
                CurrentLevel.GridList[gridY][gridX] = Part.PlayerOnGoal;
            }
            else
            {
                CurrentLevel.GridList[gridY][gridX] = Part.Player;
            }
            CurrentLevel.Player.X = gridX;
            CurrentLevel.Player.Y = gridY;
        }

        public void UpdateBlockPushLocation(int gridX, int gridY)
        {
            if (CurrentLevel.GridList[gridY][gridX] == Part.Goal)
            {
                CurrentLevel.GridList[gridY][gridX] = Part.BlockOnGoal;
            }
            else
            {
                CurrentLevel.GridList[gridY][gridX] = Part.Block;
            }
        }

        public bool CheckPointInBoundsOfLevel(int gridX, int gridY)
        {
            if (gridX > CurrentLevel.GetLevelWidth() - 1 || gridY > CurrentLevel.GetLevelHeight() - 1)
            {
                return false;
            }
            return true;
        }

        public bool CheckMoveInvolvingNoPush(int gridX, int gridY)
        {
            if (CurrentLevel.GetPartAtIndex(gridX, gridY) == Part.Empty || CurrentLevel.GetPartAtIndex(gridX, gridY) == Part.Goal)
            {
                return true;
            }
            return false;
        }

        public bool CheckMoveInvolvingPush(int gridX1, int gridY1, int gridX2, int gridY2)
        {
            if (CurrentLevel.GetPartAtIndex(gridX1, gridY1) == Part.Block || CurrentLevel.GetPartAtIndex(gridX1, gridY1) == Part.BlockOnGoal)
            {
                if (CurrentLevel.GetPartAtIndex(gridX2, gridY2) == Part.Empty || CurrentLevel.GetPartAtIndex(gridX2, gridY2) == Part.Goal)
                {
                    return true;
                }
            }
            return false;
        }

        public Point GetPointForMove(Direction moveDirection, int gridX, int gridY)
        {
            int x1 = gridX;
            int y1 = gridY;
            switch (moveDirection)
            { 
                case Direction.Up:
                    y1 = CurrentLevel.Player.Y - 1;
                    break;
                case Direction.Down:
                    y1 = CurrentLevel.Player.Y + 1;
                    break;
                case Direction.Left:
                    x1 = CurrentLevel.Player.X - 1;
                    break;
                case Direction.Right:
                    x1 = CurrentLevel.Player.X + 1;
                    break;
            }
            return new Point(x1, y1);
        }

        public Point GetPointForBlockPush(Direction moveDirection, int gridX, int gridY)
        {
            int x1 = gridX;
            int y1 = gridY;
            switch (moveDirection)
            {
                case Direction.Up:
                    y1 = CurrentLevel.Player.Y - 2;
                    break;
                case Direction.Down:
                    y1 = CurrentLevel.Player.Y + 2;
                    break;
                case Direction.Left:
                    x1 = CurrentLevel.Player.X - 2;
                    break;
                case Direction.Right:
                    x1 = CurrentLevel.Player.X + 2;
                    break;
            }
            return new Point(x1, y1);
        }

        // Pop and use last record from MoveRecord List, Not implemented Yet
        public void Undo()
        {
/*            if (GetMoveCount() > 1)
            {
                CurrentLevel.addPart(CurrentLevel.Player.MoveList[-1].CurrentPosition., CurrentLevel.Player.MoveList[-1].CurrentPosition.Y, CurrentLevel.Player.MoveList[-1].CurrentPart);
                CurrentLevel.addPart(CurrentLevel.Player.MoveList[-1].NewPosition.X, CurrentLevel.Player.MoveList[-1].NewPosition.Y, CurrentLevel.Player.MoveList[-1].NewPart);
                *//*CurrentLevel.addPart(CurrentLevel.Player.MoveList[-1].PushLocation.X, CurrentLevel.Player.MoveList[-1].PushLocation.Y, CurrentLevel.Player.MoveList[-1].PushPart);*//*
                CurrentLevel.Player.MoveList.RemoveAt(-1);
            }*/
            
        }

        // Reverse Index MoveRecord List, Pop until and MoveRecord list empty, Not implemented Yet
        public void Restart()
        {
            throw new NotImplementedException();
        }

        // Not implemented yet
        public int GetMoveCount()
        {
            // Should return length of MoveRecord List, Not implemented Yet
            return CurrentLevel.Player.MoveList.Count;
        }

        // Not implemented yet, should only check after a push is made not after every move
        public bool IsFinished()
        {
            throw new NotImplementedException();
        }

        public Level CurrentLevel { get => _currentLevel; set => _currentLevel = value; }

        public List<Level> LevelList { get => _levelList; set => _levelList = value; }
    }
}
