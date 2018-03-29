using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Tile prefab;
    public int xLength = 20;
    public int zLength = 20;
    private float xPos = 0;
    private float zPos = 0;
    public int offSet = 2;
    private Tile[,] tiles;
    
	// Use this for initialization
	void Start () {
        tiles = new Tile[xLength, zLength];
        for (int x = 0; x < xLength; x++)
        {
            for (int z = 0; z < zLength; z++)
            {
                xPos = x * prefab.transform.localScale.x;
                zPos = z * prefab.transform.localScale.z;

                Tile tile = (Tile)Instantiate(prefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                tile.transform.SetParent(this.transform);
                tile.setLocation(x,z);
                tiles[x,z] = tile;
            }
        }
	}
	
    public Tile[,] GetTiles(){
        return tiles;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
