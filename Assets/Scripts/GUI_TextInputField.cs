using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_TextInputField : MonoBehaviour
{
    [SerializeField]
    List<TMPro.TMP_InputField> _inputFields = default;

    private void OnValidate()
    {
        _inputFields = new List<TMPro.TMP_InputField>(GetComponentsInChildren<TMPro.TMP_InputField>());
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
