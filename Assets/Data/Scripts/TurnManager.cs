﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TurnManager : MonoBehaviour
{
    public int playerAmmount = 1;
	private int currentPlayerId = 0;
    public Player prefab;
    public List<Player> playerList = new List<Player>();
    public Player currentPlayer;
	public GameObject unitFactory;
	public Grid grid;
    public bool hasMoved = false;
    public bool hasSpawned = false;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < playerAmmount; i++)
        {
            Player player = (Player)Instantiate(prefab);
            player.transform.SetParent(this.transform);
            playerList.Add(player);
            player.name = "Player " + (i + 1);
			player.playerColor.GetComponent<Image>().color = Random.ColorHSV();
            player.GetComponentInChildren<Factory>().turnManager = this;
            player.playerId = i;
            if (i > 0)
            {
                player.gameObject.SetActive(false);
            }
        }
        currentPlayer = playerList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(hasMoved && hasSpawned){
            NextTurn();
        }
    }
    public void addAction(string action){
        if (action == "spawn")
        {
            hasSpawned = true;
        }
        else if (action == "movement")
        {
            hasMoved = true;
        }
    }

	public void NextTurn(){
        hasMoved = false;
        hasSpawned = false;
		if (currentPlayer != playerList[playerAmmount-1])
		{
			currentPlayerId++;;
			currentPlayer.gameObject.SetActive(false);
			currentPlayer = playerList[currentPlayerId];
			currentPlayer.gameObject.SetActive(true);
		}
		else{
			currentPlayer.gameObject.SetActive(false);
			currentPlayerId = 0;
			currentPlayer = playerList[currentPlayerId];
			currentPlayer.gameObject.SetActive(true);
		}
	}
}
