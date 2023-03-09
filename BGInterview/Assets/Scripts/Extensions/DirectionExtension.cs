using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionExtension
{
    public static Directions GetFaceDirection(this Vector2 movement){
        if(movement.y > 0)
            return Directions.North;
        else if(movement.y < 0)
            return Directions.South;
        else if(movement.x > 0)
            return Directions.East;
        else if(movement.x < 0)
            return Directions.West;
        return Directions.None;
    }

    public static float ToFloat(this Directions direction)
    {
        switch(direction){
            case Directions.North:
                return 0f;
            case Directions.East:
                return 0.8f;
            case Directions.West:
                return 1f;
            default:
                return 0.4f;
        }
    }

    public static Vector2 ToVector2(this Directions direction)
    {
        switch(direction){
            case Directions.North:
                return Vector2.up;
            case Directions.East:
                return Vector2.right;
            case Directions.West:
                return Vector2.left;
            default:
                return Vector2.down;
        }
    }

    public static int ToAngle(this Directions direction)
    {
        switch(direction){
            case Directions.North:
                return 0;
            case Directions.East:
                return 270;
            case Directions.West:
                return 90;
            default:
                return 180;
        }
    }
}