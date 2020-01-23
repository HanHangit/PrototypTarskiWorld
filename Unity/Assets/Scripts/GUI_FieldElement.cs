using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GUI_FieldElement : MonoBehaviour, IDragableTarget
{
    [SerializeField]
    private int _posX = 0;
    [SerializeField]
    private int _posY = 0;
    private List<string> _identifier = new List<string>();
	private List<string> _praedicats = new List<string>();
	[SerializeField]
    private TextMeshProUGUI _positionText = default;
    [SerializeField]
    private Button _button = default;
    [SerializeField]
    private Image _elementImage = default;
	private bool _hasElement = false;

    public event EventHandler<FieldElementEventArgs> FieldSelectChangedEvent;

    private void OnValidate()
    {
        if (_positionText == null)
        {
            _positionText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }


    public void Init(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
        _positionText.text = posX+"/"+posY;
        _button.onClick.AddListener(ButtonClicked);
        ResetElementImage();
    }

    public void ResetElementImage()
    {
        _elementImage.sprite = null;
        _elementImage.gameObject.SetActive(false);
    }

    private void ButtonClicked()
    {
	

    }

	private void ResetField()
	{
		
	}

    protected virtual void Intern_OnTestEvent(FieldElementEventArgs args)
    {
        FieldSelectChangedEvent?.Invoke(this, args);
    }

    public void OnDragEnd(Sprite image, string identifier, GUI_ObjectButton.ETyp type)
    {
		switch (type)
		{
			case GUI_ObjectButton.ETyp.None:
				Debug.Log("Type not defined");
				break;
			case GUI_ObjectButton.ETyp.Identifier:
				_identifier.Add(identifier);
				break;
			case GUI_ObjectButton.ETyp.Praedicat:
				_praedicats.Add(identifier);
				break;
			default:
				break;
		}
		_elementImage.sprite = image;
        _elementImage.gameObject.SetActive(true);

		if(!_hasElement)
			Intern_OnTestEvent(new FieldElementEventArgs(new Tuple<int, int>(_posX, _posY), _identifier, _praedicats, true));
		_hasElement = true;
	}

	[System.Serializable]
    public class FieldElementEventArgs : EventArgs
    {
        public Tuple<int, int> Position;
        public bool IsRemoving;
        public List<string> Identifier;
        public List<string> ConstantList;

        public FieldElementEventArgs(Tuple<int, int> position, List<string> identifier, List<string> constantList, bool isRemoving)
        {
            Position = position;
            IsRemoving = isRemoving;
            Identifier = identifier;
            ConstantList = constantList;
        }
    }
}

public interface IDragableTarget
{
    void OnDragEnd(Sprite _image, string  _identifier, GUI_ObjectButton.ETyp type);
}
