using System;
using System.Collections.Generic;

namespace SokobanModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();


            Level level1 = new Level("Level1");
            level1.CreateLevel(4, 4);
            level1.AddBlock(1,1);
            level1.RemovePart(1, 1);
            level1.AddGoal(2, 1);
            level1.RemovePart(2, 1);
            level1.AddPlayer(3, 1);
            level1.RemovePart(3, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            Console.WriteLine(LevelToString(level1));

            /*
                        Console.WriteLine("Showing Player move Up one tile at a time");
                        Level level3 = new Level("Level3");
                        level3.CreateLevel(3, 3);
                        level3.AddPlayer(0, 2);
                        level3.AddGoal(2, 2);
                        level3.AddBlock(2, 1);
                        game.AddLevel(level3);
                        game.Load("Level3");
                        Console.WriteLine(LevelToString(level3));
                        game.Move(Direction.Up);
                        Console.WriteLine(LevelToString(level3));

                        Console.WriteLine("Showing Player move Down one tile at a time");
                        Level level4 = new Level("Level4");
                        level4.CreateLevel(3, 3);
                        level4.AddPlayer(0, 1);
                        level4.AddGoal(2, 2);
                        level4.AddBlock(2, 1);
                        game.AddLevel(level4);
                        game.Load("Level4");
                        Console.WriteLine(LevelToString(level4));
                        game.Move(Direction.Down);
                        Console.WriteLine(LevelToString(level4));

                        Console.WriteLine("Showing Player move Left one tile at a time");
                        Level level5 = new Level("Level5");
                        level5.CreateLevel(3, 3);
                        level5.AddPlayer(1, 1);
                        level5.AddGoal(2, 2);
                        level5.AddBlock(2, 1);
                        game.AddLevel(level5);
                        game.Load("Level5");
                        Console.WriteLine(LevelToString(level5));
                        game.Move(Direction.Left);
                        Console.WriteLine(LevelToString(level5));

                        Console.WriteLine("Showing Player move Right one tile at a time");
                        Level level6 = new Level("Level6");
                        level6.CreateLevel(3, 3);
                        level6.AddPlayer(1, 1);
                        game.AddLevel(level6);
                        game.Load("Level6");
                        Console.WriteLine(LevelToString(level6));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level6));

                        Console.WriteLine("Showing Player CANNOT move through Wall");
                        Level level7 = new Level("Level7");
                        level7.CreateLevel(3, 3);
                        level7.AddPlayer(0, 0);
                        level7.AddWall(1, 0);
                        game.AddLevel(level7);
                        game.Load("Level7");
                        Console.WriteLine(LevelToString(level7));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level7));

                        Console.WriteLine("Showing Player CANNOT push Block with Wall Behind");
                        Level level8 = new Level("Level8");
                        level8.CreateLevel(3, 3);
                        level8.AddPlayer(0, 0);
                        level8.AddBlock(1, 0);
                        level8.AddWall(2, 0);
                        game.AddLevel(level8);
                        game.Load("Level8");
                        Console.WriteLine(LevelToString(level8));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level8));

                        Console.WriteLine("Showing Player Moving onto Goal");
                        Level level9 = new Level("Level9");
                        level9.CreateLevel(3, 3);
                        level9.AddPlayer(0, 0);
                        level9.AddGoal(1, 0);
                        game.AddLevel(level9);
                        game.Load("Level9");
                        Console.WriteLine(LevelToString(level9));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level9));

                        Console.WriteLine("Showing Player Moving onto Goal, then out of Goal");
                        Level level10 = new Level("Level10");
                        level10.CreateLevel(3, 3);
                        level10.AddPlayer(0, 0);
                        level10.AddGoal(1, 0);
                        game.AddLevel(level10);
                        game.Load("Level10");
                        Console.WriteLine(LevelToString(level10));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level10));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level10));

                        Console.WriteLine("Showing Player Cannot Push Block with Block Behind");
                        Level level11 = new Level("Level11");
                        level11.CreateLevel(4, 4);
                        level11.AddPlayer(0, 0);
                        level11.AddBlock(0, 1);
                        level11.AddBlock(0, 2);
                        level11.AddGoal(0, 3);
                        game.AddLevel(level11);
                        game.Load("Level11");
                        Console.WriteLine(LevelToString(level11));
                        game.Move(Direction.Down);
                        Console.WriteLine(LevelToString(level11));

                        Console.WriteLine("Showing Player Pushing Block onto Goal");
                        Level level12 = new Level("Level12");
                        level12.CreateLevel(3, 3);
                        level12.AddPlayer(1, 2);
                        level12.AddBlock(1, 1);
                        level12.AddGoal(1, 0);
                        game.AddLevel(level12);
                        game.Load("Level12");
                        Console.WriteLine(LevelToString(level12));
                        game.Move(Direction.Up);
                        Console.WriteLine(LevelToString(level12));

                        Console.WriteLine("Showing Player Pushing Block onto Empty");
                        Level level13 = new Level("Level13");
                        level13.CreateLevel(3, 3);
                        level13.AddPlayer(1, 2);
                        level13.AddBlock(1, 1);
                        game.AddLevel(level13);
                        game.Load("Level13");
                        Console.WriteLine(LevelToString(level13));
                        game.Move(Direction.Up);
                        Console.WriteLine(LevelToString(level13));

                        Console.WriteLine("Showing Player Pushing Block Up to Goal");
                        Level level14 = new Level("Level14");
                        level14.CreateLevel(3, 3);
                        level14.AddPlayer(1, 2);
                        level14.AddBlock(1, 1);
                        level14.AddGoal(1, 0);
                        game.AddLevel(level14);
                        game.Load("Level14");
                        Console.WriteLine(LevelToString(level14));
                        game.Move(Direction.Up);
                        Console.WriteLine(LevelToString(level14));

                        Console.WriteLine("Showing Player Pushing Block Down to Goal");
                        Level level15 = new Level("Level15");
                        level15.CreateLevel(3, 3);
                        level15.AddPlayer(1, 0);
                        level15.AddBlock(1, 1);
                        level15.AddGoal(1, 2);
                        game.AddLevel(level15);
                        game.Load("Level15");
                        Console.WriteLine(LevelToString(level15));
                        game.Move(Direction.Down);
                        Console.WriteLine(LevelToString(level15));

                        Console.WriteLine("Showing Player Pushing Block Left to Goal");
                        Level level16 = new Level("Level16");
                        level16.CreateLevel(3, 3);
                        level16.AddPlayer(2, 1);
                        level16.AddBlock(1, 1);
                        level16.AddGoal(0, 1);
                        game.AddLevel(level16);
                        game.Load("Level16");
                        Console.WriteLine(LevelToString(level16));
                        game.Move(Direction.Left);
                        Console.WriteLine(LevelToString(level16));

                        Console.WriteLine("Showing Player Pushing Block Right to Goal");
                        Level level17 = new Level("Level17");
                        level17.CreateLevel(3, 3);
                        level17.AddPlayer(0, 1);
                        level17.AddBlock(1, 1);
                        level17.AddGoal(2, 1);
                        game.AddLevel(level17);
                        game.Load("Level17");
                        Console.WriteLine(LevelToString(level17));
                        game.Move(Direction.Right);
                        Console.WriteLine(LevelToString(level17));

                        Console.WriteLine("Showing Player Pushing Block to Goal then off Goal");
                        Level level18 = new Level("Level18");
                        level18.CreateLevel(4, 4);
                        level18.AddPlayer(3, 1);
                        level18.AddBlock(2, 1);
                        level18.AddGoal(1, 1);
                        game.AddLevel(level18);
                        game.Load("Level18");
                        Console.WriteLine(LevelToString(level18));
                        game.Move(Direction.Left);
                        Console.WriteLine(LevelToString(level18));
                        game.Move(Direction.Left);
                        Console.WriteLine(LevelToString(level18));*/
        }

        public static string LevelToString(Level level)
        {
            string str1 = "";
            foreach (List<Part> i in level.GridList)
            {
                string str2 = "";
                foreach (Part j in i)
                {
                    string str3 = new string('*', Math.Abs(j.ToString().Length - 12));
                    str2 += "[" + j + str3 + "]";
                }
                str1 += str2 + "\n";
            }

            return str1;

        }
    }
}
