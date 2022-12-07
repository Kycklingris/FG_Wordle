using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keyboard : MonoBehaviour
{
	[SerializeField] private UnityEvent<string> keyPress;
	[SerializeField] private UnityEvent enterPress;
	[SerializeField] private UnityEvent backspacePress;

	public void KeyPress(string input)
	{
		this.keyPress.Invoke(input);
	}

	public void EnterPress()
	{
		this.enterPress.Invoke();
	}

	public void BackspacePress()
	{
		this.backspacePress.Invoke();
	}

	public void SetKeyColor(string lowerKey, Color color)
	{
		var upperKey = lowerKey.ToUpper();

		foreach (Transform child in this.gameObject.transform)
		{
			if (child.name == upperKey)
			{
				child.gameObject.GetComponent<KeyboardKey>().color = color;
				break;
			}
		}
	}

	public void ResetBoard()
	{
		foreach (KeyboardKey key in this.gameObject.GetComponentsInChildren<KeyboardKey>())
		{
			key.color = Colors.white;
		}
	}
}
