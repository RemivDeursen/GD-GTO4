using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public GameObject tile;
    private int xLength = 20;
    private int yLength = 20;
    private int xPos = -50;
    private int yPos = 0;
    private GameObject[,] tiles;
	// Use this for initialization
	void Start () {
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                tiles[x,y] = (GameObject)Instantiate(tile, new Vector3(xPos,0,yPos), Quaternion.identity);
                yPos += 5;
            }
            xPos += 5;
            yPos = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
