using System;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "The Key And The Gate");
Raylib.SetTargetFPS(60);

bool hasWon = false;

// Create instances
Door hodor = new Door(200, 200);
Key key = new Key(hodor);
key.UpdatePosition(new Vector2(700, 300));

Avatar avatar = new Avatar();

while (!Raylib.WindowShouldClose())
{
  // Updating

  if (!hasWon)
  {
    avatar.Update();
    avatar.CheckKeyCollision(key);

    if (avatar.CheckDoorCollision(hodor) && hodor.IsOpen)
    {
      hasWon = true;
    }
  }

  // Drawing

  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.WHITE);

  if (!hasWon)
  {
    hodor.Draw();
    key.Draw();
    avatar.Draw();
  }

  if (hasWon)
  {
    Raylib.DrawText("#WIN", 10, 10, 300, Color.BLACK);
  }

  Raylib.EndDrawing();
}