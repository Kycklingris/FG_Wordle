using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridPiece : MonoBehaviour
{
	private Image _image;
	private TextMeshProUGUI _text;

	public Color color
	{
		get { return this._image.color; }
		set { this._image.color = value; }
	}

	public string letter
	{
		get { return this._text.text; }
		set { this._text.text = value; }
	}

	void Awake()
	{
		this._image = this.gameObject.GetComponent<Image>();
		this._text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
	}
}
