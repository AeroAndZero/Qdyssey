using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public GameObject pawnPlacements;

	[Header("Player Controls")]
	public Player player;

	[Header("Dice Controls")]
	public DiceManager diceManager;

	private void Start()
	{
		// Initializing game board
		for(int i = 0; i < pawnPlacements.transform.childCount; i++)
		{
			Transform childPawn = pawnPlacements.transform.GetChild(i);
			GameBoard.AddPlace(new GameBoardPlace(childPawn.gameObject, childPawn.position));
		}
		Debug.Log("Game board initialized!");

		// Placing player
		player.setPosition(GameBoard.GetPlacePosition(0));

		// On roll dice event
		diceManager.onRollDice += moveToNextPlace;
	}

	public void moveToNextPlace(int offset)
	{
		player.moveToPlace(player.currentPlace + offset, true);
	}
}

public class GameBoardPlace
{
	public GameObject placeObj;
	public Vector3 position;

	public GameBoardPlace(GameObject placeObj, Vector3 position)
	{
		this.placeObj = placeObj;
		this.position = position;
	}
}

public static class GameBoard
{
	static List<GameBoardPlace> GameBoardPlaces = new List<GameBoardPlace>();

	public static void AddPlace(GameBoardPlace place)
	{
		GameBoardPlaces.Add(place);
	}

	public static Vector3 GetPlacePosition(int place)
	{
		if (place >= GameBoardPlaces.Count)
		{
			Debug.Log("No more places to go at!");
			return GameBoardPlaces[GameBoardPlaces.Count - 1].position;
		}

		return GameBoardPlaces[place].position;
	}
}