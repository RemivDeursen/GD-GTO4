using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied = false;
    public float x, y;

    public void setLocation(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector3 GetLocation()
    {
        return new Vector3(x, 0, y);
    }

    public void SetOccupied()
    {
        occupied = true;
    }
}
