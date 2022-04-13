工廠模式三個環節，抽象產品、具體產品、生產產品

``` c#

using System;

namespace ConsoleApp1
{
    abstract class Game //抽象類別定義產品概念
    {
        public abstract string Name { get; set; }

        public abstract int Price { get; set; }

        public abstract void Demo();
    }

    class CSO : Game //描述產品的細節
    {
        public override string Name { get; set; } = "CSO";

        public override int Price { get; set; } = 100;

        public override void Demo()
        {
            Console.WriteLine("CSo is Playing");
        }
    }


    class AOE3 : Game //描述產品的細節
    {
        public override string Name { get; set; } = "AOE3";

        public override int Price { get; set; } = 300;

        public override void Demo()
        {
            Console.WriteLine("AOE3 is Playing");
        }
    }

    static class GameFactory //工廠生產
    {
        public static Game GetGame(string name) //型別是Game，因為要生產Game，所以回傳Game
        {
            switch (name)
            {
                case "AOE3":

                return new AOE3();

                case "CSO":

                return new CSO();

                default:

                throw new Exception("My factory doesn't' has this game") ;
            }
        }
    }


    static class MainProgram //算是Clinet端?!
    {
        public static void Main()
        {
            Game AOE3 = GameFactory.GetGame("AOE3");

            AOE3.Demo();        

            Game CSO = GameFactory.GetGame("CSO");

            CSO.Demo();
        }
    }
}

```
