using PL1Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_TextInputField : MonoBehaviour
{
    [SerializeField]
    List<TMPro.TMP_InputField> _inputFields = default;
    public List<TMPro.TMP_InputField> InputField => _inputFields;

    public List<string> GetInputFieldText()
    {
        List<string> list = new List<string>();

        foreach (var item in InputField)
        {
            if (!string.IsNullOrEmpty(item.text))
                list.Add(item.text);
        }

        return list;
    }

    [SerializeField]
    private Button _checkAllButton = default;

    private void OnValidate()
    {
        _inputFields = new List<TMPro.TMP_InputField>(GetComponentsInChildren<TMPro.TMP_InputField>());
        _checkAllButton.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {

        List<string> results = new List<string>();

        for (int i = 0; i < _inputFields.Count; i++)
        {
            if(!string.IsNullOrEmpty(_inputFields[i].text))
            {
                results.Add( _inputFields[i].text);
            }
        }

        //Result<Formula>[] result = ModelParser.ParseSentences(results.ToArray());
        //foreach (var item in result)
        //{
        //    if (item.IsValid)
        //    {
        //        Debug.Log(item.IsValid);
        //    }
        //    else
        //    {
        //        Debug.Log(item.Message);
        //    }
        //}
    }
    private void Awake()
    {
        foreach (var item in _inputFields)
        {
            item.onEndEdit.AddListener(EndEdit);
        }
    }

    private void EndEdit(string arg0)
    { 
       Debug.Log("EndEditing");
    }
}
