using System;
using System.Collections.Generic;
using Raylib_cs;

Raylib.InitWindow(1270, 720, "gaming");
Raylib.SetTargetFPS(60);

Random yRand = new Random(720);
Random xRand = new Random(1270);
Random ranNum = new Random(100);

string displayNumber = "";
const int sliderRange = 100;
float[] sliderRangeIndex = new float[sliderRange];
float sliderValue = 0;
float sliderNobValue = 1;


List<Rectangle> snowFlake = new List<Rectangle>();
List<float> snowSpeed = new List<float>();




Rectangle slider = new Rectangle(10, 10, Raylib.GetScreenWidth() - 30, 50);
Rectangle sliderNob = new Rectangle(slider.x + 1, slider.y + 1, slider.height - 2, slider.height - 2);

float sliderNobXMax = slider.width - sliderNob.width - 1;

float unit = sliderNobXMax / Convert.ToInt32(sliderRange);



for (int i = 0; i < 2000; i++)
{
    int size = ranNum.Next(1, Convert.ToInt32(sliderValue) + 1);
    int speed = size;
    displayNumber = Convert.ToString(sliderNobValue);
    int x = xRand.Next(Raylib.GetScreenWidth());
    int y = yRand.Next(Raylib.GetScreenHeight());

    snowFlake.Add(new Rectangle(x, y, size, size));
    snowSpeed.Add(speed);
}

while (Raylib.WindowShouldClose() == false)
{

    Raylib.BeginDrawing();

    Console.WriteLine($"{sliderNobValue} {sliderNobXMax} {unit})");



    Raylib.ClearBackground(Color.SKYBLUE);

    Raylib.DrawRectangleRec(slider, Color.BLACK);


    if (Raylib.GetMouseX() > slider.x && Raylib.GetMouseX() < slider.width + slider.x - sliderNob.width &&
        Raylib.GetMouseY() > slider.y && Raylib.GetMouseY() < slider.height + slider.y)
    {
        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON) == true)
        {

            sliderNob.x = Raylib.GetMouseX();

        }
    }

    for (int i = 0; i < sliderRangeIndex.Length; i++)
    {
        sliderRangeIndex[i] = unit * i;
    }


    for (int i = 0; i < snowFlake.Count; i++)
    {
        Rectangle flake = snowFlake[i];

        snowSpeed[i] = flake.width;
        flake.height = flake.width;
        flake.y += snowSpeed[i];
        snowFlake[i] = flake;

        if (flake.y > Raylib.GetScreenHeight())
        {

            flake = snowFlake[i];
            flake.width = ranNum.Next(1, Convert.ToInt32(sliderValue) + 1);
            flake.x = xRand.Next(-Convert.ToInt32(flake.width), Raylib.GetScreenWidth());
            flake.y = -yRand.Next(Raylib.GetScreenHeight() * 2);
            snowFlake[i] = flake;
            Raylib.DrawRectangleRec(snowFlake[i], Color.WHITE);
        }
    }
    for (int i = 0; i < snowFlake.Count; i++)
    {
        Raylib.DrawRectangleRec(snowFlake[i], Color.WHITE);
    }



    Raylib.DrawRectangleRec(sliderNob, Color.BLUE);
    sliderNobValue = sliderNob.x - slider.x;
    sliderValue = sliderNobValue / unit;
    Raylib.DrawText($"{Math.Round(sliderValue)}", Convert.ToInt32(slider.x * 2), Convert.ToInt32(slider.y + slider.height + 10), Convert.ToInt32(slider.height * 3), Color.WHITE);

    Raylib.EndDrawing();
}