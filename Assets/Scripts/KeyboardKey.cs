using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKey : MonoBehaviour
{
	private Image _image;
	private Keyboard keyboard;

	public Color color
	{
		get { return this._image.color; }
		set { this._image.color = value; }
	}

	private void Awake()
	{
		this._image = this.gameObject.GetComponent<Image>();

		this.keyboard = this.gameObject.transform.parent.gameObject.GetComponent<Keyboard>();
	}

	public void KeyPress(string input)
	{
		this.keyboard.KeyPress(input);
	}
}