using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_MapSize : MonoBehaviour
{
    [SerializeField]
    private int _size = 7;

    [SerializeField]
    private GridLayoutGroup _layoutGroup = default;

    [SerializeField]
    private GUI_FieldElement _elementPrefab = default;
    [SerializeField]
    private Transform _anchor = default;

    List<GUI_FieldElement.FieldElementEventArgs> _resultObj = new List<GUI_FieldElement.FieldElementEventArgs>();

    [SerializeField]
    private Button _validateButton = default;

    private void Awake()
    {
        CreateMap();
        _validateButton.onClick.AddListener(ValidateButtonPressed);
    }



    private void CreateMap()
    {
        _layoutGroup.constraintCount = _size;
        int ySize = -1;
        for (int i = 0; i < Mathf.Pow(_size, 2); i++)
        {
            if(i % _size == 0)
            {
                ySize++;
            }
            var instance = Instantiate(_elementPrefab, _anchor);
            instance.Init(i % _size, ySize);
            instance.FieldSelectChangedEvent += TextOutput;
        }
    }

    private void TextOutput(object sender, GUI_FieldElement.FieldElementEventArgs e)
    {
        _resultObj.Add(e);
    }

    private void ValidateButtonPressed()
    {
        foreach (var item in _resultObj)
        {
            Debug.Log("---");
            Debug.Log("Element on Position: : " + item.Position.Item1 + "/" + item.Position.Item2);
            foreach (var identifier in item.Identifier)
            {
                Debug.Log("Identifier: " + identifier);
            }
        }
    }
}
