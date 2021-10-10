using System;
using System.Numerics;
using Raylib_cs;

public class Avatar
{
  private Rectangle rect = new Rectangle();
  private Key CarriedKey { get; set; }
  private float speed = 5f;

  public Avatar()
  {
    rect.width = 32;
    rect.height = 32;
  }

  public void Update()
  {
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
      movement.X = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
      movement.X = 1;
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
      movement.Y = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
      movement.Y = 1;
    }

    movement *= speed;

    rect.x += movement.X;
    rect.y += movement.Y;

    if (CarriedKey != null)
    {
      CarriedKey.UpdatePosition(movement);
    }
  }

  public void Draw()
  {
    Raylib.DrawRectangleRounded(rect, 0.25f, 1, Color.PINK);
    Raylib.DrawText("AVATAR", (int)rect.x, (int)(rect.y + rect.height), 30, Color.BLACK);
  }

  public void CheckKeyCollision(Key key)
  {
    if (key.CheckCollision(this.rect))
    {
      CarriedKey = key;
    }
  }

  public bool CheckDoorCollision(Door door)
  {
    return door.CheckCollision(this.rect);
  }

}