using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied = false;
    public Vector2 position {get; private set;}
    public Unit unit {get; private set;}

    public void SetPosition(int x, int y)
    {
        this.position = new Vector2(x,y);
    }

    public void SetUnit(Unit unit)
    {
        this.unit = unit;
        if(unit == null){
            occupied = false;
        }
        else{
            occupied = true;
        }
    }
}
