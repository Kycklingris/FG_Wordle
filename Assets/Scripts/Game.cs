using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	[SerializeField] private Keyboard keyboard;
	private GridPiece[,] grid = new GridPiece[5, 5];

	private int currentWordIndex = 0;
	private int currentLetterIndex = 0;

	private string currentWord = "";
	private string correctWord;

	void Start()
	{
		this.ResetBoard();
	}

	public void ResetBoard()
	{
		this.keyboard.ResetBoard();

		this.currentLetterIndex = 0;
		this.currentWordIndex = 0;
		this.currentWord = "";


		var x = 0;
		var y = 0;

		foreach (Transform child in this.gameObject.transform)
		{
			grid[y, x] = child.gameObject.GetComponent<GridPiece>();

			grid[y, x].letter = "";
			grid[y, x].color = Colors.white;

			x++;
			if (x == 5)
			{
				x = 0;
				y++;
			}
		}


		int randomI = Random.Range(0, Words.words.Count - 1);

		int i = 0;

		foreach (var word in Words.words)
		{
			if (randomI == i)
			{
				this.correctWord = word;
				break;
			}

			i++;
		}
	}

	public void KeyPressed(string input)
	{
		if (this.currentLetterIndex < 5)
		{
			this.grid[this.currentWordIndex, this.currentLetterIndex].letter = input;
			this.currentWord += input.ToLower();
			this.currentLetterIndex++;
		}
	}

	public void Backspace()
	{
		const string empty = "";

		if (this.currentLetterIndex > 0)
		{
			this.currentLetterIndex--;
			this.grid[this.currentWordIndex, this.currentLetterIndex].letter = empty;
			this.currentWord = this.currentWord.Remove(this.currentWord.Length - 1, 1);
		}
	}

	public void Enter()
	{
		if (this.currentLetterIndex == 5 && Words.words.Contains(this.currentWord))
		{
			this.CompareWords();
		}
	}

	public void CompareWords()
	{
		if (this.currentWord == this.correctWord)
		{
			this.Win();
			return;
		}

		LetterState[] states = new LetterState[5];

		var currentIndex = 0;
		foreach (char currentChar in this.currentWord)
		{
			var correctIndex = 0;

			var state = LetterState.Wrong;

			foreach (char correctChar in this.correctWord)
			{
				if (currentChar != correctChar)
				{
					correctIndex++;
					continue;
				}


				if (currentIndex == correctIndex)
				{
					state = LetterState.Correct;
					break;
				}
				else
				{
					state = LetterState.InWord;
					correctIndex++;
				}

			}

			states[currentIndex] = state;
			currentIndex++;
		}

		for (int i = 0; i < 5; i++)
		{
			Color color = Colors.white;

			switch (states[i])
			{
				case LetterState.Correct:
					color = Colors.green;
					break;
				case LetterState.InWord:
					color = Colors.yellow;
					break;
				case LetterState.Wrong:
					color = Colors.grey;
					break;
			}

			this.grid[this.currentWordIndex, i].color = color;

			this.keyboard.SetKeyColor(this.grid[this.currentWordIndex, i].letter, color);
		}

		this.currentWord = "";
		this.currentLetterIndex = 0;
		this.currentWordIndex++;

		if (this.currentWordIndex == 5)
		{
			this.Defeat();
		}
	}

	public void Defeat()
	{
		Debug.Log("Defeat");
		this.ResetBoard();
	}

	public void Win()
	{
		Debug.Log("Win");
		this.ResetBoard();
	}
}

public enum LetterState
{
	Correct,
	InWord,
	Wrong,
}