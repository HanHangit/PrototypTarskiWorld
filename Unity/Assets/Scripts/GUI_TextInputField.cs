﻿using PL1Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_TextInputField : MonoBehaviour
{
    [SerializeField]
    List<GUI_TextInputElement> _inputFields = default;
    public List<GUI_TextInputElement> InputField => _inputFields;

    internal List<GUI_TextInputElement> GetTextInputElement()
    {
        return _inputFields;
    }

    public List<string> GetInputFieldText()
    {
        List<string> list = new List<string>();

        foreach (var item in InputField)
        {
            if(!item.IsEmptyString())
            {
                list.Add(item.GetInputText());
            }
        }

        return list;
    }

    public List<GUI_TextInputElement> GetGuiTextElementsWithText()
    {
        var result = new List<GUI_TextInputElement>();
        foreach (GUI_TextInputElement item in InputField)
        {
            if (!item.IsEmptyString())
            {
                result.Add(item);
            }
        }
        return result;
    }

    private void OnValidate()
    {
        _inputFields = new List<GUI_TextInputElement>(GetComponentsInChildren<GUI_TextInputElement>());
    }
}
