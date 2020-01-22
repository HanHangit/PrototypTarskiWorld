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

        if(result.IsValid)
            if(result.Value[0] is Predicate predicate)
            {
                Debug.Log("Predicate:" + predicate.Identifier);
                Debug.Log("Argument:" + ((Constant)predicate.Arguments[0]).Value);
            }
        }
    }
}
