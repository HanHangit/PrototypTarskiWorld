using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_ObjectButton : MonoBehaviour
{
	public enum ETyp
	{
		None, Identifier, Praedicat
	}

	[SerializeField]
	public ETyp _currentTyp = default;

    [SerializeField]
    private Button _button = default;

    [SerializeField]
    private Image _image = default;
    [SerializeField]
    private string _identifier = "";

    public Sprite GetSprite()
    {
        return _image.sprite;
    }

    public string GetIdentifier()
    {
        return _identifier;
    }

	public ETyp GetCurrentTyp()
	{
		return _currentTyp;
	}
}
