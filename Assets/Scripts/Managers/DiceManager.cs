using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
	public Action<int> onRollDice;
	public float RollDiceTime = 4f;
	public TMP_Text diceText;
	
	public IEnumerator _rollDice()
	{
		// Text animation
		float time = 0f;
		int frame = 0;
		int multiplier = 1;

		while(time <= RollDiceTime)
		{
			if(frame % multiplier == 0)
			{
				diceText.text = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 6f)).ToString();
			}

			if(frame % 256 == 0)
			{
				multiplier += multiplier;
			}
			Debug.Log(multiplier + " multiplier");

			frame += 1;
			time += Time.deltaTime;

			yield return null;
		}

		// Get the number
		int roll = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 6f));
		diceText.text = roll.ToString();
		onRollDice.Invoke(roll);
	}

	public void rollDice()
	{
		StartCoroutine(_rollDice());
	}
}

