﻿public struct Point
{
    public int x {get; private set; }
    public int y {get; private set; }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }
}