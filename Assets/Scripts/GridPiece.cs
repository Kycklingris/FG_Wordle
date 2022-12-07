using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridPiece : MonoBehaviour
{
	private Color _color;
	private TextMeshProUGUI _text;

	public Color color
	{
		get { return this._color; }
		set { this._color = value; }
	}

	public string letter
	{
		get { return this._text.text; }
		set { this._text.text = value; }
	}

	void Awake()
	{
		this._color = this.gameObject.GetComponent<Image>().color;
		this._text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
	}
}
