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

    private List<GUI_FieldElement.FieldElementEventArgs> _resultObj = new List<GUI_FieldElement.FieldElementEventArgs>();
    public List<GUI_FieldElement.FieldElementEventArgs> Objs => _resultObj;

    private void Awake()
    {
        CreateMap();
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
        if (e.IsRemoving)
        {
            var element = CheckIfElementInList(e);
            if (element != null)
            {
                _resultObj.Remove(element);
            }
        }
        else
        {
            _resultObj.Add(e);
        }
    }

    private GUI_FieldElement.FieldElementEventArgs CheckIfElementInList(GUI_FieldElement.FieldElementEventArgs element)
    {
        foreach (GUI_FieldElement.FieldElementEventArgs item in _resultObj)
        {
            if(element.Position.Item1 == element.Position.Item1 && element.Position.Item2 == element.Position.Item2)
            {
                return item;
            }
        }
        return null;
    }
}
