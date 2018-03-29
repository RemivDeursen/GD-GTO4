using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	private bool isMoving = false;
	public float movementSpeed;
	public int currentMovement;
	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
		{
			transform.localPosition = Vector3.MoveTowards(
				this.transform.localPosition, 
				Vector3.zero, 
				movementSpeed * Time.deltaTime);
			if (this.transform.localPosition == Vector3.zero)
			{
				isMoving = false;
			}
		}
	}

	public bool Move(Tile targetTile){
		Tile currentTile = this.transform.GetComponentInParent<Tile>();
		int range = 0;
		int xrange = (int)Mathf.Abs((targetTile.position.x - currentTile.position.x));
		int yrange = (int)Mathf.Abs((currentTile.position.y - targetTile.position.y));

		if (xrange >= yrange)
		{
			range = xrange;
		}
		else{
			range = yrange;
		}

		if (range <= currentMovement)
		{
			if (currentTile.position != Vector2.zero)
			{
				currentTile.SetUnit(null);
				targetTile.SetUnit(this);
				this.transform.SetParent(targetTile.transform);
				isMoving = true;
			}
		}
		return isMoving;
	}
	
}
