using PL1Structure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_ModelParser : MonoBehaviour
{
    [SerializeField]
    private string _input = "Tet(a)";

    private void Start()
    {
        Result<Formula>[] result = ModelParser.ParseSentences(_input);

        if (result[0].IsValid)
            if (result[0].Value is Predicate predicate)
            {
                Debug.Log("Predicate:" + predicate.Identifier);
                Debug.Log("Argument:" + ((Constant)predicate.Arguments[0]).Value);
            }

        List<string> sentences = new List<string> { "Tet(a)" };
        List<string> arguments = new List<string> { "a" };
        List<string> predicates = new List<string> { "Tet" };
        List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0) };

        var resultValidate = ModelValidater.ValidateModel(dataStructs, sentences);

        Debug.Log("Sentence is " + resultValidate.Value[0]);
    }
}
