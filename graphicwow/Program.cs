using System;
using System.Collections.Generic;
using Raylib_cs;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int globalIndent = 10;

            Raylib.InitWindow(1270, 720, "balls");
            Raylib.SetTargetFPS(60);

            List<Slider> sliderList = new List<Slider>();


            sliderList.Add(new Slider(0, 10, (Raylib.GetScreenWidth() / 3) * 2, 100, 100, globalIndent));


            while (Raylib.WindowShouldClose() == false)

            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLUE);

                for (int i = 0; i < sliderList.Count; i++)
                {
                    sliderList[i].Update();
                    sliderList[i].Draw();
                    sliderList[i].Text();
                }


                Raylib.EndDrawing();

            }
        }
    }
}
