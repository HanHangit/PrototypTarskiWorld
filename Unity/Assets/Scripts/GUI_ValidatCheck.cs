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

    //Predicates ist das ganze
    // AB C _> Constante
    // Tet -> Identifier
    // Sentences
    // Nur Felder geben wo ein Char drin ist

    public void Start()
    {
        _validButton.onClick.AddListener(ValidButtonClicked);
    }

    private void ValidButtonClicked()
    {
        List<GUI_FieldElement.FieldElementEventArgs> board = _mapSize.Objs;
        List<DataStruct> boardInDataStruct = new List<DataStruct>();
        foreach (var item in board)
        {
            item.DebugMessage();
            boardInDataStruct.Add(new DataStruct(item.Identifier, item.ConstantList, item.Position.Item1, item.Position.Item2));
        }
        List<string> text = _textInputField.GetInputFieldText();
        Validate(text, boardInDataStruct);
    }

    private void Validate(List<string> sentences, List<DataStruct> boardInfo )
    {
        Result<List<bool>> resultValidate = ModelValidater.ValidateModel(boardInfo, sentences);
        foreach (var item in resultValidate.Value)
        {
            Debug.Log(item);
        }
    }

    //private void Start()
    //{
    //    Result<Formula>[] result = ModelParser.ParseSentences(_input);

    //    if (result[0].IsValid)
    //        if (result[0].Value is Predicate predicate)
    //        {
    //            Debug.Log("Predicate:" + predicate.Identifier);
    //            Debug.Log("Argument:" + ((Constant)predicate.Arguments[0]).Value);
    //        }

    //    List<string> sentences = new List<string> { "Tet(a)" };
    //    List<string> arguments = new List<string> { "a" };
    //    List<string> predicates = new List<string> { "Tet" };
    //    List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0) };

  

    //    Debug.Log("Sentence is " + resultValidate.Value[0]);
    //}
}
