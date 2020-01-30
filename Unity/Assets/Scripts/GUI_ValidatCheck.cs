using PL1Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_ValidatCheck : MonoBehaviour
{
    [SerializeField]
    private GUI_MapSize _mapSize = default;

    [SerializeField]
    private GUI_TextInputField _textInputField = default;

    [SerializeField]
    private Button _validButton = default;

    [SerializeField]
    private bool _debugMode = false;

    //Predicates ist das ganze
    // AB C _> Constante
    // Tet -> Identifier
    // Sentences
    // Nur Felder geben wo ein Char drin ist

    public void Start()
    {
        _validButton.onClick.AddListener(ValidButtonClicked);
        foreach (var item in _textInputField.GetTextInputElement())
        {
            item.ValidateButton.onClick.AddListener(() => SingleValidateButtonClicked(item));
        }
    }

    private void SingleValidateButtonClicked(GUI_TextInputElement item)
    {
        if (item.IsEmptyString())
        {
            Debug.Log("Empty String and Button can be pressed. Something is wrong -> button can not to be interactable");
        }
        else
        {
            List<string> text = new List<string>();
            text.Add(item.GetInputText());
            var list = new List<GUI_TextInputElement>();
            list.Add(item); 
            Validate(list, text, GetBoardInformation());
        }
    }

    private void ValidButtonClicked()
    {
       List<GUI_TextInputElement> textElements = _textInputField.GetGuiTextElementsWithText();
       Validate(textElements, GetTextListFromTextElement(textElements), GetBoardInformation());
    }

    private List<string> GetTextListFromTextElement(List<GUI_TextInputElement> textElements)
    {
        List<string> result = new List<string>();
        foreach (var item in textElements)
        {
            if (item.IsEmptyString())
            {
                Debug.Log("Text shoult be empty. Something goes wrong here");
            }
            else
            {
                result.Add(item.GetInputText());
            }
        }
        return result;
    }

    private List<DataStruct> GetBoardInformation()
    {
        List<GUI_FieldElement.FieldElementEventArgs> board = _mapSize.Objs;
        List<DataStruct> boardInDataStruct = new List<DataStruct>();
        foreach (var item in board)
        {
            if (_debugMode)
            {
                item.DebugMessage();
            }

            boardInDataStruct.Add(new DataStruct(item.Identifier, item.ConstantList, item.Position.Item1, item.Position.Item2));
        }

        return boardInDataStruct;
    }

    private void Validate(List<GUI_TextInputElement> elements, List<string> sentences, List<DataStruct> boardInfo )
    {
        Result<List<bool>> resultValidate = ModelValidater.ValidateModel(boardInfo, sentences);
        var inputElements = _textInputField.GetTextInputElement();
        for (int i = 0; i < resultValidate.Value.Count; i++)
        {

            elements[i].Validate(resultValidate.Value[i]);
        }
    }
}
