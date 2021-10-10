using System;
using System.Numerics;
using Raylib_cs;

public class Key
{
  private Door targetDoor;
  private Rectangle rect = new Rectangle();

  public Key(Door target)
  {
    targetDoor = target;
    rect.width = 32;
    rect.height = 32;
  }

  public void Draw()
  {
    if (!targetDoor.IsOpen)
    {
      Raylib.DrawRectangleRounded(rect, 0.25f, 1, Color.BLUE);
      Raylib.DrawText("KEY", (int)rect.x, (int)(rect.y + rect.height), 30, Color.BLACK);
    }
  }

  public void UpdatePosition(Vector2 movement)
  {
    rect.x += movement.X;
    rect.y += movement.Y;

    if (targetDoor.CheckCollision(this.rect))
    {
      targetDoor.IsOpen = true;
    }
  }

  public bool CheckCollision(Rectangle otherRectangle)
  {
    return Raylib.CheckCollisionRecs(this.rect, otherRectangle);
  }
}