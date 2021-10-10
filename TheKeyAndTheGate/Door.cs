using System;
using Raylib_cs;

public class Door
{
  private Rectangle rect;
  public bool IsOpen { get; set; } = false;

  public Door(int x, int y)
  {
    rect = new Rectangle(x, y, 32, 32);
  }

  public void Draw()
  {
    if (IsOpen)
    {
      Raylib.DrawRectangleRounded(rect, 0.25f, 1, Color.GREEN);
    }
    else
    {
      Raylib.DrawRectangleRounded(rect, 0.25f, 1, Color.RED);
    }

    Raylib.DrawText("DOOR", (int)rect.x, (int)(rect.y + rect.height), 30, Color.BLACK);
  }

  public bool CheckCollision(Rectangle otherRectangle)
  {
    return Raylib.CheckCollisionRecs(this.rect, otherRectangle);
  }
}