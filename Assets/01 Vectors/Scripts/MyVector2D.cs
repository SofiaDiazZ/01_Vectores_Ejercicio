using System;
using UnityEngine;


[Serializable]
public struct MyVector2D
{
    public float x;
    public float y;

    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    } 

    public void Draw(Color color)
    {
        Debug.DrawLine(start: Vector3.zero, end: new Vector3(x, y), color);
    }

    public void Draw(MyVector2D newOrigin, Color color)
    {
        Vector3 start = new Vector3(newOrigin.x, newOrigin.y);
        Vector3 end = new Vector3(x: newOrigin.x + x, y: newOrigin.y + y);
        Debug.DrawLine(start, end, color);
    }

    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(x: a.x + b.x, y: a.y + b.y);
    }

    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(x: a.x - b.x, y: a.y - b.y);
    }

    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(x: a.x * b, y: a.y * b);
    }

    public static MyVector2D operator *(float b, MyVector2D a)
    {
        return new MyVector2D(x: a.x * b, y: a.y * b);
    }
}

