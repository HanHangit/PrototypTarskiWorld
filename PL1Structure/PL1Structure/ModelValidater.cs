using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public class ModelValidater
    {
        #region Public

        public static Result<List<bool>> ValidateModel(List<DataStruct> modelDatas, List<string> sentences)
        {
            var parseSentences = ModelParser.ParseSentences(sentences);
            var parseDataStructures = DataParser.ParseDataStructures(modelDatas);
            Result<List<bool>> result = Result<List<bool>>.CreateResult(false, null, "Something wrong in " + nameof(ValidateModel));
            List<bool> modelResults = new List<bool>();

            if (!parseDataStructures.IsValid)
                result = Result<List<bool>>.CreateResult(false, null, parseDataStructures.Message);
            else
            {
                foreach (var formulaSentence in parseSentences)
                {
                    if (!formulaSentence.IsValid)
                        modelResults.Add(false);
                    else
                    {
                        bool isSentenceTrue = false;
                        Predicate predicateSentence = formulaSentence.Value as Predicate;
                        foreach (var dataSentence in parseDataStructures.Value)
                            foreach (var pred in dataSentence.Predicates)
                                if (pred.Equals(predicateSentence))
                                    isSentenceTrue = true;
                        modelResults.Add(isSentenceTrue);
                    }

                }
            }

            result = Result<List<bool>>.CreateResult(true, modelResults);
            return result;
        }

        #endregion
    }
}
