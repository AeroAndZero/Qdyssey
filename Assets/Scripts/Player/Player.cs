using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
	[HideInInspector]
	public GameObject playerObj;
	public int currentPlace = 0;
	public float movePlaceSpeed = 0.8f;

	void Awake()
	{
		playerObj = this.gameObject;
	}

	public Vector3 getPosition()
	{
		return playerObj.transform.position;
	}

	public void setPosition(Vector3 position)
	{
		playerObj.transform.position = position;
	}

	public void moveToPlace(int place, bool doLerp)
	{
		currentPlace = place;
		Vector3 endPosition = GameBoard.GetPlacePosition(place);

		if (doLerp)
		{
			StartCoroutine(_moveToPlaceLerp(movePlaceSpeed, endPosition));
		}
		else
		{
			setPosition(endPosition);
		}
	}

	IEnumerator _moveToPlaceLerp(float duration, Vector3 endPosition)
	{
		float time = 0;
		Vector3 startPosition = playerObj.transform.position;

		while(time <= duration)
		{
			playerObj.transform.position = Vector3.Lerp(startPosition, endPosition, time/duration);

			time += Time.deltaTime;
			yield return null;
		}

		playerObj.transform.position = endPosition;
	}
}
